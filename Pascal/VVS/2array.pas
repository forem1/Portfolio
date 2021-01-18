uses crt;

var
  a: array [1..10000, 1..10000] of integer;

procedure write_array(c, b: integer);
var i, j: integer;
begin
  for i := 1 to c do
  begin
    for j := 1 to b do
    begin
      a[i, j] := i * j;
    end;
  end;
  writeln('End write');
end;

procedure read_array(c, b, d: integer);
var i, j: integer;
begin
  for i := 1 to c do
  begin
    for j := 1 to b do
    begin
      write(a[i, j]:d);
    end;
    writeln;
  end;
end;

begin
  write_array(42, 42);
  delay(1000);
  read_array(42, 42, 5);//10 - 4; 25 - 5
end.