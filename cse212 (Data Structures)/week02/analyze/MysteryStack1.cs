public static class MysteryStack1 {
    public static string Run(string text) {
        var stack = new Stack<char>();
        foreach (var letter in text)
            stack.Push(letter);

        var result = "";
        while (stack.Count > 0)
            result += stack.Pop();

        return result;
    }
}

// What does the code do: It receives a text (racecar for example), it creates a stack and pushes each letter of the word separetely
// then it creates a result variable. While stack's size is greater than zero, result receives the popped letter from stack
// It reverses the string
// racecar = racecar
// stressed = desserts
//a nut for a jar of tuna = anut fo raj a rof tun a