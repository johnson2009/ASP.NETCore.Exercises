
using System.Linq.Expressions;
using ExpressionTreeToString;
using 表达式树;

using var ctx = new TestDbContext();

/* Func<Book, bool> f1 = b => b.Price > 5 || b.AuthorName.Contains("Aman");
Expression<Func<Book, bool>> expression = b => b.Price > 5 || b.AuthorName.Contains("Aman");
Console.WriteLine(f1);
Console.WriteLine(expression); */
Expression<Func<Book, bool>> e = b => b.Price > 5 || b.AuthorName.Contains("Aman");
Console.WriteLine(e.ToString("Object notation", "C#"));
