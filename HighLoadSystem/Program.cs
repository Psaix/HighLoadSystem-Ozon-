//Инициализируем переменные для быстрого(буферизованного) ввода и вывода.
using var input = new StreamReader(Console.OpenStandardInput());
using var output = new StreamWriter(Console.OpenStandardOutput());

//Инициализируем переменную и присваиваем ей значение первой входной строки - количество входных строк.
var rows = int.Parse(input.ReadLine());

//Инициализируем динамический массив строк, куда будем добавлять ответы.
List<string> answers = new List<string>();

//Создаем цикл для работы с каждой строкой.
for(int i = 0; i < rows; i++)
{
    //Инициализируем строку с ответом "YES".
    string answer = "YES";

    //Создаем динамический массив символов, преобразуя входную строку.
    List<char> letters = new List<char>(input.ReadLine().ToCharArray());

    //Если последний элемент массива равен 'М' либо первый элемент не равен 'М', ответу присваиваем "NO".
    if(letters[letters.Count() - 1] == 'M' || letters[0] != 'M')
    {
        answer = "NO";
    }
    //Если размер массива равен 1 - ответу присваиваем "NO".
    else if(letters.Count() == 1)
    {
        answer = "NO";
    }
    //Если размер массива равен 2 и первый элемент не равен 'M', а второй элемент не равен 'D', ответу присваиваем "NO".
    else if(letters.Count() == 2)
    {
        if(letters[0] != 'M' || letters[1] != 'D')
        {
            answer = "NO";
        }
    }
    //В ином случае входим в тело условия else.
    else
    {
        //Так как у символов должен быть определенный порядок расположения, проверяем каждый следующий символ(элемент) после найденного.
        //Если следующий за найденным символ верный, продолжаем идти по массиву, ответ остается равен - "YES".
        //В ином случае ответу присваиваем "NO" и выходим из цикла.
        for(int j = 0; j < letters.Count() - 1; j++)
        {
            if(letters[j] == 'M')
            {
                if(letters[j + 1] == 'M')
                {
                    answer = "NO";
                    break;
                }
            }
            else if(letters[j] == 'R')
            {
                if(letters[j + 1] != 'C')
                {
                    answer = "NO";
                    break;
                }
            }
            else if(letters[j] == 'C')
            {
                if(letters[j + 1] != 'M')
                {
                    answer = "NO";
                    break;
                }
            }
            else if(letters[j] == 'D')
            {
                if(letters[j + 1] != 'M')
                {
                    answer = "NO";
                    break;
                }
            }

        }
    }
    //Добавляем строку с ответом в массив строк с ответами.
    answers.Add(answer);
}
//Выводим каждый элемент массива с ответами в терминал.
foreach(string element in answers)
{
    output.WriteLine(element);
}