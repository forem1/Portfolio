function CircleS(R: real): real;
const
  pi = 3.14;
begin
  CircleS := pi * sqr(R)
end;

const
  n = 3;

var
  R: real;
  i: byte;

begin
  for i := 1 to n do begin
    write('R = ');
    readln(R);
    writeln('Площадь круга: ', CircleS(R):0:2);
    writeln
  end;
  readln
end.