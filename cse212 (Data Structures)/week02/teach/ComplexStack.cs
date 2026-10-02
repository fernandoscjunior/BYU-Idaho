public static class ComplexStack {
    public static bool DoSomethingComplicated(string line) {
        var stack = new Stack<char>();
        foreach (var item in line) {
            if (item is '(' or '[' or '{') {
                stack.Push(item);
            }
            else if (item is ')') {
                if (stack.Count == 0 || stack.Pop() != '(')
                    return false;
            }
            else if (item is ']') {
                if (stack.Count == 0 || stack.Pop() != '[')
                    return false;
            }
            else if (item is '}') {
                if (stack.Count == 0 || stack.Pop() != '{')
                    return false;
            }
        }

        return stack.Count == 0;
    }
}
// if char is ( [ { add, if item is ) ] } then if stack is empty or stack pop is not ( [ { return false
//the function verifies if text closes ( [ { 