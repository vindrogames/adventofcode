IO.puts("Hola que tal")
{:ok, body} = File.read("text.txt")
IO.puts(body)