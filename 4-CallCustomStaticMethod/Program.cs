using _4_CallCustomStaticMethod;
using Newtonsoft.Json;

List<Person> persons = new()
{
    new Person { Name = "john", Age = 20 },
    new Person { Name = "John", Age = 21 },
    new Person { Name = "Bing", Age = 22 }
};

var filter = new Filter
{
    Id = "Name",
    Operator = Operator.NewContains,
    Value = "john"
};
var boolExp = Exps.GetBoolExpression(filter);

filter = new Filter
{
    Id = "Age",
    Operator = Operator.ToString
};
var strExp = Exps.GetStrExpression(filter);

//get all the name contains "john" or "John"
var filteredCollection = persons.AsQueryable().Where(boolExp).Select(strExp).ToList();
var filteredCollection1 = persons.AsQueryable().Where(x => x.Age.ToString() == "20").Select(x => x.Age.ToString()).ToList();
Console.WriteLine(JsonConvert.SerializeObject(filteredCollection));
Console.WriteLine(JsonConvert.SerializeObject(filteredCollection1));

using (var dbContext = new TestContext())
{
    //报错
    //p => p.Name.NewContains("john", StringComparison.OrdinalIgnoreCase)
    //p => StringExts.ToString(p.Age)
    var query = dbContext.Person.Select(strExp);
    var result = query.Where(x => x.Equals("20")).ToList();
}