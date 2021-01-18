procedure SortDec3(var A, B, C: real);
var
  t: real;
begin
  if A < B then begin
    t := B;
    B := A;
    A := t
  end;
  if A < C then begin
    t := C;
    C := A;
    A := t
  end;
  if B < C then begin
    t := C;
    C := B;
    B := t
  end
end;

var
  A, B, C: real;
  i: byte;

begin
  for i := 1 to 2 do
  begin
    writeln('Введите три вещественные числа: ');
    readln(A, B, C);
    SortDec3(A, B, C);
    writeln(A, ' ', B, ' ', C)
  end;
  readln
end.