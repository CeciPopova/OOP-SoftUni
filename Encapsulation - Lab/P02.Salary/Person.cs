namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
            FirstName = firstName;
            LastName = lastName;
            Age = age;
            Salary = salary;
        }

        public string FirstName { get; private set; }

        public string LastName { get; private set; }
        public int Age { get; private set; }
        public decimal Salary { get; private set; }

        public void IncreaseSalary(decimal percentage)
        {
            if (this.Age >= 30)
            {
                this.Salary *= 1 + percentage / 100;
            }
            else
            {
                this.Salary *= 1 + percentage / 200;
            }
        }
        public override string ToString()
        {

            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
