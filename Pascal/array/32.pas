var
  Mass: array[1..100] of integer;
  i, N, num: integer;

begin
  write(' N = ');
  readln(N); //Вводим размер
  writeln('Введите ', N, ' целых чисел:');
  writeln;
  for i := 1 to N do
    read(mass[i]); //вводим элементы массива

  writeln;
  num := 0; //начальный номер локального минимума
  write('Результат: ');
  for i := 1 to N do
  begin //проверка первого элемента
    if i = 1 then 
    begin//если 1-й < 2-го
      if mass[1] < mass[2] then
        num := 1 //присваиваем 1
    end
    else //проверем элемент N
    if i = N then 
    begin
      if mass[N] < mass[N - 1] then
        num := N//номеру локального минимума присваиваем N
    end //все остальное
    else
    if (mass[i] < mass[i - 1]) and (mass[i] < mass[i + 1]) then
      num := i; //присваиваем i номеру лок. минимума
    if num > 0 then //если номер изменился, то выводим результат
    begin
      writeln('Номер первого локального минимума: ', num); 
      exit//т.к. больше нечего проверять
    end
  end;
  writeln('Локального минимума нет.'); //если ничего не найдено
end.