namespace PierreARNAUDET.Modules.DOT.Texts
{
    using UnityEngine;
    using UnityEngine.Events;
    using UnityEngine.UI;

    using PierreARNAUDET.Core.Attributes;

    using DG.Tweening;

    public class TextTextDOT : UTextDOT
    {
        [Data]
        [SerializeField] Text text;
        public override Text Text { get => text; set => text = value; }

        [Settings]
        [SerializeField] string endValue;
        public string EndValue { get => endValue; set => endValue = value; }
        [SerializeField] float duration;
        public float Duration { get => duration; set => duration = value; }
        [SerializeField] bool richTextEnabled;
        public bool RichTextEnabled { get => richTextEnabled; set => richTextEnabled = value; }
        [SerializeField] ScrambleMode scrambleMode;
        public ScrambleMode ScrambleMode { get => scrambleMode; set => scrambleMode = value; }
        [SerializeField] string scrambleChars;
        public string ScrambleChars { get => scrambleChars; set => scrambleChars = value; }

        [Events]
        [SerializeField] UnityEvent @event;
        public override UnityEvent @Event { get => @event; set => @event = value; }

        public void DOText(string newEndValue, float newDuration, bool newRichTextEnabled, ScrambleMode newScrambleMode, string newScrambleChars)
        {
            endValue = newEndValue;
            duration = newDuration;
            richTextEnabled = newRichTextEnabled;
            scrambleMode = newScrambleMode;
            scrambleChars = newScrambleChars;
            DOText();
        }

        public void DOText()
        {
            text.DOText(endValue, duration, richTextEnabled, scrambleMode, scrambleChars);
            @event.Invoke();
        }
    }
}