// expresiones lambda
Func<int, int, int> sub = (a, b) => a - b;

Func<int, int> some = a => a + 1;

Func<int, int> some2 = a => 
{
    a = a*2;
    return a;
};

Some3((a, b) => a + b, 5);

void Some3(Func<int, int, int> fn, int number)
{
   var result = fn(number, number);
}