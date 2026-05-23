using System;
using System.Collections.Generic;
using System.Linq;
class ScriptureReference
{
    public string ReferenceText { get; private set; }

    public ScriptureReference(string reference)
    {
        ReferenceText = reference;
    }
}