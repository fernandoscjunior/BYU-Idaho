public static class MysteryStack2 {
    private static bool IsFloat(string text) {
        return float.TryParse(text, out _);
    }

    //Receives a text, creates a stack. Then it separates each word in the text and analysis them.
    //50
    //4
    //To get invalid 1 = 3 + 3
    //To get invalid 2 = 5 0 /
    //To get invalid 3 = s 
    //To get invalid 4 = 5 5 + 5 
    //function realized a mathematical operation with the last two items in a stack if there are two items in a stack that are numbers.
    public static float Run(string text) {
        var stack = new Stack<float>();
        foreach (var item in text.Split(' ')) {
            if (item == "+" || item == "-" || item == "*" || item == "/") {
                if (stack.Count < 2)
                    throw new ApplicationException("Invalid Case 1!");

                var op2 = stack.Pop();
                var op1 = stack.Pop();
                float res;
                if (item == "+") {
                    res = op1 + op2;
                }
                else if (item == "-") {
                    res = op1 - op2;
                }
                else if (item == "*") {
                    res = op1 * op2;
                }
                else {
                    if (op2 == 0)
                        throw new ApplicationException("Invalid Case 2!");

                    res = op1 / op2;
                }

                stack.Push(res);
            }
            else if (IsFloat(item)) {
                stack.Push(float.Parse(item));
            }
            else if (item == "") {
            }
            else {
                throw new ApplicationException("Invalid Case 3!");
            }
        }

        if (stack.Count != 1)
            throw new ApplicationException("Invalid Case 4!");

        return stack.Pop();
    }
}