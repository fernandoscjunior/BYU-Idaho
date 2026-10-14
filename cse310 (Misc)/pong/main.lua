-- Imports
push = require "push"

-- Constants
WINDOW_WIDTH = 1280
WINDOW_HEIGHT = 720
V_WIDTH = 432
V_HEIGHT = 243
WINNING_POINTS = 3
PADDLE_SPEED = 180
PADDLE_WIDTH = 5
PADDLE_HEIGHT = 20
BALL_WIDTH = 4
BALL_HEIGHT = 4

-- Load function, prepares stuff so the game runs smoothly
function love.load()
    love.graphics.setDefaultFilter("nearest", "nearest")
    largeFont = love.graphics.newFont("font.ttf", 32)
    smallFont = love.graphics.newFont("font.ttf", 8)
    love.graphics.setFont(largeFont)
    math.randomseed(os.time())

    sounds = {
        ["paddle_hit"] = love.audio.newSource("sounds/paddle_hit.wav", "static"),
        ["score"] = love.audio.newSource("sounds/score.wav", "static"),
        ["wall_hit"] = love.audio.newSource("sounds/wall_hit.wav", "static")
    }

    love.window.setMode(WINDOW_WIDTH, WINDOW_HEIGHT, {
        resizable = false,
        vsync = true,
        fullscreen = false
    })
    push.setupScreen(V_WIDTH, V_HEIGHT, { upscale = "normal" }) -- Setting virtual screen to make pixels crunchy :P

    -- Important Variables
    player1Score = 0
    player2Score = 0

    player1y = 30
    player2y = V_HEIGHT - 50
    player1x = 10
    player2x = V_WIDTH - 15

    ballX = V_WIDTH / 2 - 2
    ballY = V_HEIGHT / 2 - 2

    ballDX = math.random(2) == 1 and 200 or -100
    ballDY = math.random(-50, 50)

    gameState = 'start'
end

-- Handles keyboard input other than player movement
function love.keypressed(key)
    if key == "escape" then
        love.event.quit()
    end

    if key == "Enter" or key == "return" then
        if gameState == "start" then
            gameState = "play"
        elseif gameState == "over" then
            player1Score = 0
            player2Score = 0

            gameState = "start"
        else
            gameState = "start"

            ballX = V_WIDTH / 2 - 2
            ballY = V_HEIGHT / 2 - 2

            ballDX = math.random(2) == 1 and 200 or -100
            ballDY = math.random(-50, 50) * 1.5
        end
    end
end

-- Update function
function love.update(dt)
    
    -- Detects upper and lower screen boundary collision and reverse if collided
    if ballY <= 0 then
        ballY = 0
        ballDY = -ballDY
        sounds["wall_hit"]:play()
    end
    -- -4 to account for the ball's size
    if ballY >= V_HEIGHT - 4 then
        ballY = V_HEIGHT - 4
        ballDY = -ballDY
        sounds["wall_hit"]:play()
    end

    -- Detects if ball passed by a paddle, increases the score and resets the ball
    if ballX < 0 then
        player2Score = player2Score + 1

        -- Resetting ball
        ballX = V_WIDTH / 2 - 2
        ballY = V_HEIGHT / 2 - 2
        ballDX = math.random(2) == 1 and 100 or -100
        ballDY = math.random(-50, 50)

        gameState = 'start'
        sounds["score"]:play()
    end

    if ballX > V_WIDTH then
        player1Score = player1Score + 1

        -- Resetting ball
        ballX = V_WIDTH / 2 - 2
        ballY = V_HEIGHT / 2 - 2
        ballDX = math.random(2) == 1 and 100 or -100
        ballDY = math.random(-50, 50)

        gameState = 'start'
        sounds["score"]:play()
    end

    if player1Score ==WINNING_POINTS or player2Score == WINNING_POINTS then
        gameState = "over"
    end

    -- If ball is in collision with any paddle, change its x direction and randomizes y
    if collision(player1x, player1y) then
        ballDX = -ballDX * 1.03
        ballX = player1x + 5
        -- keep velocity going in the same direction, but randomize it
        if ballDY < 0 then
            ballDY = -math.random(10, 150)
        else
            ballDY = math.random(10, 150)
        end
        sounds["paddle_hit"]:play()
    end

    if collision(player2x, player2y) then
        ballDX = -ballDX * 1.03
        ballX = player2x - 4

        if ballDY < 0 then
            ballDY = -math.random(10, 150)
        else
            ballDY = math.random(10, 150)
        end
        sounds["paddle_hit"]:play()
    end

    -- Player 1 movement
    if love.keyboard.isDown("w") then
        player1y = math.max(0, player1y + -PADDLE_SPEED * dt)
    elseif love.keyboard.isDown("s") then
        player1y = math.min(V_HEIGHT - 20, player1y + PADDLE_SPEED * dt)
    end

    -- Player 2 movement
    if love.keyboard.isDown("up") then
        player2y = math.max(0, player2y + -PADDLE_SPEED * dt)
    elseif love.keyboard.isDown("down") then
        player2y = math.min(V_HEIGHT - 20, player2y + PADDLE_SPEED * dt)
    end

    -- Ball Movement
    if gameState == "play" then
        ballX = ballX + ballDX * dt
        ballY = ballY + ballDY * dt
    end
end

-- Detects if ball is in collision with the received (x, y) coordinates
function collision(x, y)
    if ballX >= x + PADDLE_WIDTH or x >= ballX + BALL_WIDTH then 
        return false
    end

    if ballY >= y + PADDLE_HEIGHT or y >= ballY + BALL_HEIGHT then
        return false
    end

    -- if the above aren't true, they are overlapping
    return true
end

-- Render function
function love.draw()
    -- Initializing virtual resolution
    push.start()

    -- Prints Players' scores
    love.graphics.clear(40/255, 45/255, 52/255, 1)
    love.graphics.print(tostring(player1Score), V_WIDTH / 2 - 50, V_HEIGHT / 2 - 80)
    love.graphics.print(tostring(player2Score), V_WIDTH / 2 + 30, V_HEIGHT / 2 - 80)

    if gameState == "start" then
        love.graphics.printf("Press Enter to start", 0, 10, V_WIDTH, "center")
    elseif gameState == "over" then
        if player1Score == WINNING_POINTS then
            love.graphics.printf("Player 1 won!", 0, 10, V_WIDTH, "center")
        elseif player2Score == WINNING_POINTS then
            love.graphics.printf("Player 2 won!", 0, 10, V_WIDTH, "center")
        end
    end

    -- Prints paddle 1
    love.graphics.rectangle("fill", player1x, player1y, PADDLE_WIDTH, PADDLE_HEIGHT)

    -- Prints paddle 2
    love.graphics.rectangle("fill", player2x, player2y, PADDLE_WIDTH, PADDLE_HEIGHT)

    -- Prints ball
    love.graphics.rectangle("fill", ballX, ballY, BALL_WIDTH, BALL_HEIGHT)

    -- Ends virtual resolution
    push.finish()
end
