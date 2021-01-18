function IsPalindrome(var K: integer): boolean;
  
  function DigitCount(var CopyK, R: integer): byte;
  var
    c: byte;
  begin
    R := 1;
    c := 0;
    repeat
      inc(c);
      R := R * 10;
      CopyK := CopyK div 10;
    until CopyK = 0;
    R := R div 10;
    DigitCount := c
  end;


var
  CopyK, R: integer;
  DigitFirst, DigitLast, Q: byte;
begin
  CopyK := K;
  Q := DigitCount(CopyK, R); 
  IsPalindrome := true;
  if Q > 1 then
    repeat
      DigitFirst := K div R;
      DigitLast := K mod 10;
      if DigitFirst <> DigitLast then begin
        IsPalindrome := false;
        break//выходим из цикла
      end;
      K := K mod R;
      K := K div 10; //удаляю последнюю цифру числа
      R := R div 100;
      Q := Q - 2;
    until Q < 2;
end;

//-------------main-------
const
  n: byte = 10;

var
  K: integer;
  i: byte;
  num: integer;

begin
  for i := 1 to n do 
  begin
    write('Введите целое положительное число: ');
    readln(K);
    writeln(' является ли оно палиндромом?  ', IsPalindrome(K));
    if IsPalindrome(K) then num:=num+1;
    writeln
  end;
  Write(num);
end.