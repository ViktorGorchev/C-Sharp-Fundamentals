namespace GitHubTracker.Models
{
    using System;
    using System.Text;

    public class Comment
    {
        private string text;
        

        public Comment(User author, string text)
        {
            this.Author = author;
            this.Text = text;
        }

        public User Author { get; set; }

        public string Text
        {
            get
            {
                return this.text;
            }

            set
            {
                if (string.IsNullOrEmpty(value) || value.Length < 2)
                {
                    throw new ArgumentException("The text must be at least 2 symbols long");
                }

                this.text = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(this.Text);
            sb.AppendFormat("-- {0}", this.Author.UserName);

            return sb.ToString();
        }
    }
}