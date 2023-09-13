
using Lesson;
using static Lesson.Macuv;

var arrSelecion = Macuv.Sort(arr, SortAlgorithmType.Selection);
Console.WriteLine("\n" + "Sorted array :");
foreach (int bubble in arrSelecion)
Console.Write(bubble + " ");

var arrBubble = Macuv.Sort(arr, SortAlgorithmType.Bubble);
Console.WriteLine("\n" + "Sorted array :");
foreach (int bubble in arrBubble)
Console.Write(bubble + " ");

var arrInsertion = Macuv.Sort(arr, SortAlgorithmType.Insertion);
Console.WriteLine("\n" + "Sorted array :");
foreach (int bubble in arrInsertion)
Console.Write(bubble + " ");