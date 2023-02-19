namespace oop_project
{
   
    internal class MyComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return this.Value;
        }

        public MyComboBoxItem(string value, string text)
        {
            this.Value = value;
            this.Text= text;
        }
    }
}