var custQuery =
    from cust in customers
    group cust by cust.City into custGroup
    where custGroup.Count() > 2
    orderby custGroup.Key
    select custGroup;
_______________________________________________________________
Data transformation example:

var peopleInSeattle = (from student in students
                    where student.City == "Seattle"
                    select student.Last)
                    .Concat(from teacher in teachers
                            where teacher.City == "Seattle"
                            select teacher.Last);
_______________________________________________________________
Select subset es object example:

var query = from cust in Customer  
            select new {Name = cust.Name, City = cust.City};
_______________________________________________________________
Performing operation example:

// Data source.
        double[] radii = { 1, 2, 3 };

        // LINQ query using method syntax.
        IEnumerable<string> output = 
            radii.Select(r => $"Area for a circle with a radius of '{r}' = {r * r * Math.PI:F2}");
_______________________________________________________________
Method syntax and query syntax

//Query syntax:
        IEnumerable<int> numQuery1 =
            from num in numbers
            where num % 2 == 0
            orderby num
            select num;

//Method syntax:
        IEnumerable<int> numQuery2 = numbers.Where(num => num % 2 == 0).OrderBy(n => n);
_______________________________________________________________
