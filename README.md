# AnalizatorKursTFYaG
 
Написать программу синтаксического анализа автоматного языка операторов цикла языка QBasic, имеющих вид:

FOR <идентификатор счетчика>=<константа 1>TO<константа 2>STEP<шаг>
         <оператор присваивания>
         EXIT FOR
NEXT <идентификатор счетчика>

<оператор присваивания> :: = <идентификатор>=<константа>

<шаг> - целое число;
<константа 1>,<константа 2>,<константа> - целое число;
<идентификатор> - идентификатор, начинается с буквы, включает буквы, цифры, не допускает пробелы и специальные символы, ввести ограничение на длину (не более 8 символов) и не может быть зарезервированным словом (FOR, TO, STEP, EXIT, NEXT).

Семантика:
Построить таблицу идентификаторов и констант. Подсчитать число раз выполнения цикла (если это возможно). Учесть перечисленные выше ограничения на идентификаторы и константы. Не допускать дублирование идентификаторов.
Сообщать об ошибках при анализе, указывая курсором место ошибки и ее содержание.
