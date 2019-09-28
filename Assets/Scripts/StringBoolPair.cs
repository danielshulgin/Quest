using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;

[Serializable]
class StringBoolPair : IEquatable<StringBoolPair>
{
    public string tagName;
    public bool value;

    public bool Equals(StringBoolPair other)
    {
        return other.value == value && other.tagName == tagName;
    }
}

