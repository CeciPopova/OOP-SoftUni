namespace Person
{
    public class Person
    {
        private string name;
        private int age;
        public string Name { get; set; }
        public virtual int Age
        {
            get
            {
                return age;
            }
            set
            {
                if (value < 0)
                {
                    this.age = 0;
                }
                else
                {
                    this.age = value;
                }
            }
        }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public override string ToString()
        {
            return $"Name: {this.Name}, Age: {this.Age}";
        }
    }
}
