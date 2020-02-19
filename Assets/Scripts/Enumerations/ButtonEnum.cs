namespace Core.Enumerations
{
    using System.Collections.Generic;

    public class MouseButtons
    {
        [System.Flags] public enum Buttons {Left = 1, Right = 1 << 1, Middle = 1 << 2}
        Dictionary<Buttons, int> IntCorresponding = new Dictionary<Buttons, int>() { { Buttons.Left, 0}, { Buttons.Right, 1}, { Buttons.Middle, 2} };
    }
}