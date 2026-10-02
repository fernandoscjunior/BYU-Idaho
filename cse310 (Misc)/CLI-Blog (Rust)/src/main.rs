use std::fs::{File, OpenOptions};
use std::io::{self, Read, Write};

use crossterm::{
    cursor,
    event::{self, Event, KeyCode, KeyModifiers},
    execute,
    terminal::{
        self, disable_raw_mode, enable_raw_mode, ClearType,
        EnterAlternateScreen, LeaveAlternateScreen,
    },
};

fn main() -> io::Result<()> {
    println!("Welcome to Cli-Blog v.1.0!");

    println!(
        r"
     ,-----.,--.,--.,-----.  ,--.
    '  .--./|  |`--'|  |) /_ |  | ,---.  ,---.
    |  |    |  |,--.|  .-.  \|  || .-. || .-. |
    '  '--'\|  ||  ||  '--' /|  |' '-' '' '-' '
     `-----'`--'`--'`------' `--' `---' .`-  /
                                        `---'
    "
    );

    println!("1 - Create file");
    println!("2 - Edit file");

    let mut choice = String::new();
    io::stdin().read_line(&mut choice)?;

    match choice.trim() {
        "1" => create_file()?,
        "2" => edit_file()?,
        _ => println!("Invalid option."),
    }

    Ok(())
}

fn create_file() -> io::Result<()> {
    println!("New file's name (do not enter the extension yet):");

    let mut name = String::new();
    io::stdin().read_line(&mut name)?;
    let name = name.trim();

    if name.is_empty() {
        println!("File name cannot be empty.");
        return Ok(());
    }

    println!("Choose the file format (txt/md):");

    let mut format = String::new();
    io::stdin().read_line(&mut format)?;
    let format = format.trim().to_lowercase();

    if format != "txt" && format != "md" {
        println!("Invalid format. Please choose txt or md.");
        return Ok(());
    }

    let filename = format!("{name}.{format}");

    editor(&filename, String::new())
}

fn edit_file() -> io::Result<()> {
    println!("Input file's name (with its extension):");

    let mut name = String::new();
    io::stdin().read_line(&mut name)?;
    let name = name.trim();

    let mut content = String::new();

    match File::open(name) {
        Ok(mut file) => {
            file.read_to_string(&mut content)?;
            editor(name, content)
        }

        Err(error) if error.kind() == io::ErrorKind::NotFound => {
            println!("File not found.");
            Ok(())
        }

        Err(error) => Err(error),
    }
}

struct TerminalGuard;

impl TerminalGuard {
    fn new() -> io::Result<Self> {
        enable_raw_mode()?;

        execute!(
            io::stdout(),
            EnterAlternateScreen,
            cursor::Hide,
            terminal::Clear(ClearType::All),
            cursor::MoveTo(0, 0)
        )?;

        Ok(Self)
    }
}

impl Drop for TerminalGuard {
    fn drop(&mut self) {
        let mut stdout = io::stdout();

        let _ = execute!(
            stdout,
            cursor::Show,
            LeaveAlternateScreen
        );

        let _ = disable_raw_mode();
    }
}

fn editor(name: &str, initial_content: String) -> io::Result<()> {
    let _terminal = TerminalGuard::new()?;

    let mut buffer = initial_content;
    let mut cursor_position = buffer.len();

    loop {
        draw_editor(&buffer, cursor_position)?;

        if event::poll(std::time::Duration::from_millis(100))? {
            if let Event::Key(key_event) = event::read()? {
                // Ignore key release/repeat events.
                if key_event.kind != event::KeyEventKind::Press {
                    continue;
                }
            
                // Ctrl+Q = save and quit.
                if key_event.code == KeyCode::Char('q')
                    && key_event.modifiers.contains(KeyModifiers::CONTROL)
                {
                    save(name, &buffer)?;
                    break;
                }
            
                match key_event.code {
                    KeyCode::Char(c) => {
                        buffer.insert(cursor_position, c);
                        cursor_position += c.len_utf8();
                    }
                
                    KeyCode::Enter => {
                        buffer.insert(cursor_position, '\n');
                        cursor_position += 1;
                    }
                
                    KeyCode::Backspace => {
                        if cursor_position > 0 {
                            if let Some(previous_char) =
                                buffer[..cursor_position].chars().next_back()
                            {
                                let len = previous_char.len_utf8();
                            
                                buffer.drain(cursor_position - len..cursor_position);
                                cursor_position -= len;
                            }
                        }
                    }
                
                    KeyCode::Delete => {
                        if cursor_position < buffer.len() {
                            if let Some(next_char) =
                                buffer[cursor_position..].chars().next()
                            {
                                let len = next_char.len_utf8();
                            
                                buffer.drain(cursor_position..cursor_position + len);
                            }
                        }
                    }
                
                    KeyCode::Left => {
                        if cursor_position > 0 {
                            if let Some(previous_char) =
                                buffer[..cursor_position].chars().next_back()
                            {
                                cursor_position -= previous_char.len_utf8();
                            }
                        }
                    }
                
                    KeyCode::Right => {
                        if cursor_position < buffer.len() {
                            if let Some(next_char) =
                                buffer[cursor_position..].chars().next()
                            {
                                cursor_position += next_char.len_utf8();
                            }
                        }
                    }
                
                    KeyCode::Esc => {
                        break;
                    }
                
                    _ => {}
                }
            }
        }
    }
    Ok(())
}

fn draw_editor(buffer: &str, cursor_position: usize) -> io::Result<()> {
    let mut stdout = io::stdout();

    // Completely redraw the alternate screen.
    execute!(
        stdout,
        cursor::MoveTo(0, 0),
        terminal::Clear(ClearType::All)
    )?;

    println!("--- Editor --- (Ctrl+Q to save and exit)");
    println!();

    print!("{buffer}");

    // Find the cursor's row and column.
    let before_cursor = &buffer[..cursor_position];

    let row = before_cursor.matches('\n').count() as u16 + 2;

    let column = match before_cursor.rfind('\n') {
        Some(position) => before_cursor[position + 1..].chars().count(),
        None => before_cursor.chars().count(),
    } as u16;

    execute!(stdout, cursor::MoveTo(column, row))?;

    stdout.flush()?;

    Ok(())
}

fn save(name: &str, content: &str) -> io::Result<()> {
    let mut file = OpenOptions::new()
        .write(true)
        .create(true)
        .truncate(true)
        .open(name)?;

    file.write_all(content.as_bytes())?;
    file.flush()?;

    Ok(())
}
