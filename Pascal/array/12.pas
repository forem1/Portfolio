var
  A: array[1..200] of integer;
  N, i: word;

begin
  writeln('Введите четный размр массива: ');
  write(' N = ');
  readln(N);
  writeln(' Введите массив', N, ':');
  for i := 1 to N do //Вводим массив
    read(a[i]);
  writeln(' Четные элементы: '); 
  write(' '); 
  i := 0; //массив с нуля
  while i < N do
  begin
    inc(i, 2); //каждую итерацию увеличиваем на 2
    write(' ', a[i])//выводим элемент массива
  end;
  readln;
end.