using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TFYAiG_analizator_var13
{
    class Analyzer
    {
        enum Statments
        {
            S, F, ERROR,
            C1, C2, C3, C4, C5, C6, C7, C8, C9, C10,
            C11, C12, C13, C14, C15, C16, C17, C18, C19, C20,
            C21, C22, C23, C24, C25, C26, C27, C28, C29, C30,
            C31, C32, C33, C34, C35, C36, C37, C38, C39, C40,
            C41, C42, C43, C44, C45, C46, C47, C48, C49, C50, C51, C52,
            enter1, enter2,enter3,enter4
        }

        private static int left = 0;
        private static int right = 0;
        private static int step = 1;
        private static int len;
        private static int pos;
        private static char c;

        private static List<string> identifikators = new List<string>();
        private static List<int> constants = new List<int>();
        private static List<string> reserved = new List<string> { "FOR", "TO", "STEP", "EXIT", "NEXT" };
        private static Statments state;
        private static StringBuilder identifikator = new StringBuilder();
        private static StringBuilder constant = new StringBuilder();
        private static StringBuilder temp = new StringBuilder();

        public static List<string> Identifikators
        { get { return identifikators; } }
       
        public static List<int> Constants
        { get { return constants; } }

        public static int Pos
        { get { return pos; } }

        public static string getAnalize(string inputString)
        {
            string result = null;
            identifikators.Clear();
            constants.Clear();
            identifikator.Clear();
            constant.Clear();
            temp.Clear();
            len = inputString.Length;
            step = 1;
            pos = 0;
            state = Statments.S;

            while (state != Statments.ERROR && state != Statments.F)
            {
                if (pos < len)
                {
                    c = inputString[pos];
                switch (state)
                {

                    case Statments.S:
                        switch (c)
                        {
                            case ' ':
                                pos++;
                                break;
                            case 'F':
                                state = Statments.C1;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"F\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C1:
                        switch (c)
                        {
                            case 'O':
                                state = Statments.C2;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"O\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C2:
                            switch (c)
                            {
                                case 'R':{
                                    state = Statments.C3;
                                    pos++;
                                    break;}
                                default:
                                    state = Statments.ERROR;
                                    result = String.Format("Ожидалась \"R\", получено \"{0}\". Позиция:{1}", c, pos);
                                    break;
                            }
                            break;

                    case Statments.C3:
                        switch (c)
                        {
                            case ' ':
                                state = Statments.C4;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \" \", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C4:
                        if (c.Equals(' '))
                            pos++;
                        else
                            if (char.IsLetter(c))
                            {
                                state = Statments.C5;
                                identifikator.Append(c);
                                pos++;
                            }
                            else { state = Statments.ERROR; result = String.Format("Идентификатор должен начинаться с буквы. Позиция:{0}", pos); }
                        break;

                    case Statments.C5:
                        if (char.IsLetterOrDigit(c))
                        {
                            
                            identifikator.Append(c);
                            pos++;
                        }
                        else
                            switch (c)
                            {
                                case ' ':
                                    if (!identifikators.Contains(identifikator.ToString()) && !(reserved.Contains(identifikator.ToString())) && (identifikator.Length < 9))
                                    {
                                        state = Statments.C6;
                                        identifikators.Add(identifikator.ToString());
                                        temp.AppendFormat(identifikator.ToString());
                                        identifikator.Clear();
                                        pos++;
                                    }
                                    else
                                    {
                                        state = Statments.ERROR;
                                        if (identifikators.Contains(identifikator.ToString()))
                                            result = String.Format("Идентификатор \"{0}\" уже есть. Позиция:{1}", identifikator, pos);
                                        else if (reserved.Contains(identifikator.ToString()))
                                            result = String.Format("Идентификатор \"{0}\" является зарезервированным словом. Позиция:{1}", identifikator, pos);
                                        else if (identifikator.Length > 8)
                                            result = String.Format("Идентификатор \"{0}\" имеет длину больше 8 символов. Позиция:{1}", identifikator, pos);
                                    }
                                    break;
                                case '=':
                                    if (!identifikators.Contains(identifikator.ToString()) && !(reserved.Contains(identifikator.ToString())) && (identifikator.Length < 9))
                                    {
                                        state = Statments.C7;
                                        identifikators.Add(identifikator.ToString());
                                        temp.AppendFormat(identifikator.ToString());
                                        identifikator.Clear();
                                        pos++;
                                    }
                                    else
                                    {
                                        state = Statments.ERROR;
                                        if (identifikators.Contains(identifikator.ToString()))
                                            result = String.Format("Идентификатор \"{0}\" уже есть. Позиция:{1}", identifikator, pos);
                                        else if (reserved.Contains(identifikator.ToString()))
                                            result = String.Format("Идентификатор \"{0}\" является зарезервированным словом. Позиция:{1}", identifikator, pos);
                                        else if (identifikator.Length > 8)
                                            result = String.Format("Идентификатор \"{0}\" имеет длину больше 8 символов. Позиция:{1}", identifikator, pos);
                                    }
                                    break;
                            }
                        break;

                    case Statments.C6:
                        switch (c)
                        {
                            case ' ':
                                pos++;
                                break;
                            case '=':
                                state = Statments.C7;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается \"=\". Позиция:{0}", pos);
                                break;
                        }
                        break;


                    case Statments.C7:
                        if (char.IsDigit(c) && !c.Equals('0'))
                        {
                            state = Statments.C9;
                            constant.Append(c);
                            pos++;
                        }
                        else if (c.Equals('0'))
                        {
                            state = Statments.C10;
                            constant.Append(c);
                            pos++;
                        }
                        else
                            switch (c)
                            {
                                case ' ':
                                    pos++;
                                    break;
                                case '-':
                                    state = Statments.C8;
                                    constant.Append(c);
                                    pos++;
                                    break;
                                default:
                                    state = Statments.ERROR;
                                    result = String.Format("Непредвиденный символ, ожидается целая константа. Позиция:{0}", pos);
                                    break;
                            }
                        break;

                    case Statments.C8:
                        if (char.IsDigit(c) && !c.Equals('0'))
                        {
                            state = Statments.C9;
                            constant.Append(c);
                            pos++;
                        }
                        else { state = Statments.ERROR; result = String.Format("Непредвиденный символ, ожидается целая константа. Позиция:{0}", pos); }
                        break;


                    case Statments.C9:
                        if (char.IsDigit(c))
                        {
                            constant.Append(c);
                            pos++;
                        }
                        else
                            switch (c)
                            {
                                case ' ':
                                    state = Statments.C11;
                                    try { constants.Add(int.Parse(constant.ToString())); }
                                    catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                    left = int.Parse(constant.ToString());
                                    constant.Clear();
                                    pos++;
                                    break;
                                default:
                                    state = Statments.ERROR;
                                    result = String.Format("Непредвиденный символ, ожидается пробел. Позиция:{0}", pos);
                                    break;
                            }
                        break;

                    case Statments.C10:
                        switch (c)
                        {
                            case ' ':
                                state = Statments.C11;
                                try { constants.Add(int.Parse(constant.ToString())); }
                                catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                left = int.Parse(constant.ToString());
                                constant.Clear();
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается \" \". Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.C11:
                        switch (c)
                        {
                            case ' ':
                                pos++;
                                break;
                            case 'T':
                                state = Statments.C12;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"T\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C12:
                        switch (c)
                        {
                            case 'O':
                                state = Statments.C13;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"O\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;
                    case Statments.C13:
                        switch (c)
                        {
                            case ' ':
                                state = Statments.C14;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается пробел. Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.C14:
                        if (char.IsDigit(c) && !c.Equals('0'))
                        {
                            state = Statments.C17;
                            constant.Append(c);
                            pos++;
                        }
                        else if (c.Equals('0'))
                        {
                            state = Statments.C16;
                            constant.Append(c);
                            pos++;
                        }
                        else
                            switch (c)
                            {
                                case ' ':
                                    pos++;
                                    break;
                                case '-':
                                    state = Statments.C15;
                                    constant.Append(c);
                                    pos++;
                                    break;
                                default:
                                    state = Statments.ERROR;
                                    result = String.Format("Непредвиденный символ, ожидается целая константа. Позиция:{0}", pos);
                                    break;
                            }
                        break;

                    case Statments.C15:
                        if (char.IsDigit(c) && !c.Equals('0'))
                        {
                            state = Statments.C17;
                            constant.Append(c);
                            pos++;
                        }
                        else { state = Statments.ERROR; result = String.Format("Непредвиденный символ, ожидается целая константа. Позиция:{0}", pos); }
                        break;

                    case Statments.C16:
                        switch (c)
                        {
                                case ' ':
                                    pos++;
                                    break;
                            case '\r':
                                state = Statments.enter1;
                                try { constants.Add(int.Parse(constant.ToString())); }
                                catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                right = int.Parse(constant.ToString());
                                constant.Clear();
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается \"\n\". Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.C17:
                        if (char.IsDigit(c))
                        {
                            constant.Append(c);
                            pos++;
                        }
                        else
                            switch (c)
                            {
                                case '\r':
                                    state = Statments.enter1;
                                    try { constants.Add(int.Parse(constant.ToString())); }
                                    catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                    right = int.Parse(constant.ToString());
                                    constant.Clear();
                                    pos++;
                                    break;
                                case ' ':
                                    state = Statments.C18;
                                    try { constants.Add(int.Parse(constant.ToString())); }
                                    catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                    right = int.Parse(constant.ToString());
                                    constant.Clear();
                                    pos++;
                                    break;
                                default:
                                    state = Statments.ERROR;
                                    result = String.Format("Непредвиденный символ, ожидается пробел или новая строка. Позиция:{0}", pos);
                                    break;
                            }
                        break;

                    case Statments.C18:
                        switch (c)
                        {
                            case 'S':
                                state = Statments.C19;
                                pos++;
                                break;
                            case '\r':
                                state = Statments.enter1;
                                pos++;
                                break;
                            case ' ':
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"S\" или новая строка, получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C19:
                        switch (c)
                        {
                            case 'T':
                                state = Statments.C20;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"T\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C20:
                        switch (c)
                        {
                            case 'E':
                                state = Statments.C21;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"E\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C21:
                        switch (c)
                        {
                            case 'P':
                                state = Statments.C22;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"P\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C22:
                        switch (c)
                        {
                            case ' ':
                                state = Statments.C23;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \" \", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C23:
                        if (char.IsDigit(c) && !c.Equals('0'))
                        {
                            state = Statments.C26;
                            constant.Append(c);
                            pos++;
                        }
                        else if (c.Equals('0'))
                        {
                            state = Statments.C24;
                            constant.Append(c);
                            pos++;
                        }
                        else
                            switch (c)
                            {
                                case ' ':
                                    pos++;
                                    break;
                                case '-':
                                    state = Statments.C25;
                                    constant.Append(c);
                                    pos++;
                                    break;
                                default:
                                    state = Statments.ERROR;
                                    result = String.Format("Непредвиденный символ, ожидается целая константа. Позиция:{0}", pos);
                                    break;
                            }
                        break;

                    case Statments.C24:
                        switch (c)
                        {
                            case ' ':
                                state = Statments.C27;
                                try { constants.Add(int.Parse(constant.ToString())); }
                                catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                step = int.Parse(constant.ToString());
                                constant.Clear();
                                pos++;
                                break;
                            case '\r':
                                state = Statments.enter1;
                                try { constants.Add(int.Parse(constant.ToString())); }
                                catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; } 
                                step = int.Parse(constant.ToString());
                                constant.Clear();
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается ввод новой строки. Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.C25:
                        if (char.IsDigit(c) && !c.Equals('0'))
                        {
                            state = Statments.C26;
                            constant.Append(c);
                            pos++;
                        }
                        else { state = Statments.ERROR; result = String.Format("Непредвиденный символ, ожидается целая константа. Позиция:{0}", pos); }
                        break;

                    case Statments.C26:
                        if (char.IsDigit(c))
                            {
                                constant.Append(c);
                                pos++;
                            }
                            else
                                switch (c)
                                {

                                    case '\r':
                                        state = Statments.enter1;
                                        try { constants.Add(int.Parse(constant.ToString())); }
                                        catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                        step = int.Parse(constant.ToString());
                                        constant.Clear();
                                        pos++;
                                        break;
                                    case ' ':
                                        state = Statments.C27;
                                        try { constants.Add(int.Parse(constant.ToString())); }
                                        catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                        step = int.Parse(constant.ToString());
                                        constant.Clear();
                                        pos++;
                                        break;
                                    default:
                                    state = Statments.ERROR;
                                    result = String.Format("Непредвиденный символ, ожидается пробел. Позиция:{0}", pos);
                                    break;
                                }
                            break;

                    case Statments.enter1:
                            switch (c)
                            {
                                case '\n':
                                    state = Statments.C28;
                                    pos++;
                                    break;
                            }
                            break;

                    case Statments.C27:
                        switch (c)
                        {
                            case ' ':
                                pos++;
                                break;
                            case '\r':
                                state = Statments.enter1;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается новая стрOка. Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.C28:
                        if (c.Equals(' '))
                                pos++;
                            else
                                if (char.IsLetter(c))
                                {
                                    state = Statments.C29;
                                    identifikator.Append(c);
                                    pos++;
                                }
                                else { state = Statments.ERROR; result = String.Format("Идентификатор должен начинаться с буквы. Позиция:{0}", pos); }
                            break;



                    case Statments.C29:
                            if (char.IsLetterOrDigit(c))
                            {
                                identifikator.Append(c);
                                pos++;
                            }
                            else
                                switch (c)
                                {
                                    case '=':
                                        if (!identifikators.Contains(identifikator.ToString()) && !(reserved.Contains(identifikator.ToString())) && (identifikator.Length < 9))
                                        {
                                            state = Statments.C31;
                                            identifikators.Add(identifikator.ToString());
                                            identifikator.Clear();
                                            pos++;
                                        }
                                        else
                                        {
                                            state = Statments.ERROR;
                                            if (identifikators.Contains(identifikator.ToString()))
                                                result = String.Format("Идентификатор \"{0}\" уже есть. Позиция:{1}", identifikator, pos);
                                            else if (reserved.Contains(identifikator.ToString()))
                                                result = String.Format("Идентификатор \"{0}\" является зарезервированным словом. Позиция:{1}", identifikator, pos);
                                            else if (identifikator.Length > 8)
                                                result = String.Format("Идентификатор \"{0}\" имеет длину больше 8 символов. Позиция:{1}", identifikator, pos);
                                        }
                                        break;
                                    case ' ':
                                        if (!identifikators.Contains(identifikator.ToString()) && !(reserved.Contains(identifikator.ToString())) && (identifikator.Length < 9))
                                        {
                                            state = Statments.C30;
                                            identifikators.Add(identifikator.ToString());
                                            identifikator.Clear();
                                            pos++;
                                        }
                                        else
                                        {
                                            state = Statments.ERROR;
                                            if (identifikators.Contains(identifikator.ToString()))
                                                result = String.Format("Идентификатор \"{0}\" уже есть. Позиция:{1}", identifikator, pos);
                                            else if (reserved.Contains(identifikator.ToString()))
                                                result = String.Format("Идентификатор \"{0}\" является зарезервированным словом. Позиция:{1}", identifikator, pos);
                                            else if (identifikator.Length > 8)
                                                result = String.Format("Идентификатор \"{0}\" имеет длину больше 8 символов. Позиция:{1}", identifikator, pos);
                                        }
                                        break;
                                    default:
                                        state = Statments.ERROR;
                                        result = String.Format("Непредвиденный символ, ожидается \",\", \"]\", \" \", идентификатор или константа. Позиция:{0}", pos);
                                        break;
                                }
                            break;

                    case Statments.C30:
                        switch (c)
                        {
                            case ' ':
                                pos++;
                                break;
                            case '=':
                                state = Statments.C31;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается \"=\" или \" \". Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.C31:
                        if (char.IsDigit(c) && !c.Equals('0'))
                        {
                            constant.Clear();
                            state = Statments.C34;
                            constant.Append(c);
                            pos++;
                        }
                        else if (c.Equals('0'))
                        {
                            state = Statments.C33;
                            constant.Append(c);
                            pos++;
                        }
                        else
                            switch (c)
                            {
                                case ' ':
                                    pos++;
                                    break;
                                case '-':
                                    state = Statments.C32;
                                    constant.Append(c);
                                    pos++;
                                    break;
                                default:
                                    state = Statments.ERROR;
                                    result = String.Format("Непредвиденный символ, ожидается целая константа. Позиция:{0}", pos);
                                    break;
                            }
                        break;

                    case Statments.C32:
                        switch (c)
                        {
                            case ' ':
                                pos++;
                                break;
                        }
                        if (char.IsDigit(c) && !c.Equals('0'))
                        {
                            state = Statments.C34;
                            constant.Append(c);
                            pos++;
                        }
                        else { state = Statments.ERROR; result = String.Format("Непредвиденный символ, ожидается целая константа. Позиция:{0}", pos); }
                        break;

                    case Statments.C33:
                        switch (c)
                        {
                            case '\r':
                                state = Statments.enter2;
                                try { constants.Add(int.Parse(constant.ToString())); }
                                catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                constant.Clear();
                                pos++;
                                break;
                            case ' ':
                                state = Statments.C35;
                                try { constants.Add(int.Parse(constant.ToString())); }
                                catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                constant.Clear();
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается пробел или следющая строка. Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.C34:
                        if (char.IsDigit(c))
                        {
                            constant.Append(c);
                            pos++;
                        }
                        else
                            switch (c)
                            {
                                case '\r':
                                    state = Statments.enter2;
                                    try { constants.Add(int.Parse(constant.ToString())); }
                                    catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                    constant.Clear();
                                    pos++;
                                    break;
                                case ' ':
                                    state = Statments.C35;
                                    try { constants.Add(int.Parse(constant.ToString())); }
                                    catch { state = Statments.ERROR; result = "Константа вышла за пределы целого типа"; break; }
                                    constant.Clear();
                                    pos++;
                                    break;
                                default:
                                    state = Statments.ERROR;
                                    result = String.Format("Непредвиденный символ, ожидается \" \" или \"\n\". Позиция:{0}", pos);
                                    break;
                            }
                        break;

                    case Statments.enter2:
                        switch (c)
                        {
                            case '\n':
                                state = Statments.C36;
                                pos++;
                                break;
                        }
                        break;

                    case Statments.C35:
                        switch (c)
                        {
                            case ' ':
                                pos++;
                                break;
                            case '\r':
                                state = Statments.enter2;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась новая строка. Позиция:{1}", pos);
                                break;
                        }
                        break;

                    case Statments.C36:
                        switch (c)
                        {
                            case 'E':
                                state = Statments.C38;
                                pos++;
                                break;
                            case 'N':
                                state = Statments.C37;
                                pos++;
                                break;
                            case ' ':
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"E\" или \"N\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C37:
                        switch (c)
                        {
                            case 'E':
                                state = Statments.C48;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"E\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C38:
                        switch (c)
                        {
                            case 'X':
                                state = Statments.C39;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"X\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C39:
                        switch (c)
                        {
                            case 'I':
                                state = Statments.C40;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"I\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C40:
                        switch (c)
                        {
                            case 'T':
                                state = Statments.C41;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"T\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C41:
                        switch (c)
                        {
                            case ' ':
                                state = Statments.C42;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается \" \". Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.C42:
                        switch (c)
                        {
                            case 'F':
                                state = Statments.C43;
                                pos++;
                                break;
                            case ' ':
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"F\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C43:
                        switch (c)
                        {
                            case 'O':
                                state = Statments.C44;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"O\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C44:
                        switch (c)
                        {
                            case 'R':
                                state = Statments.C45;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"R\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C45:
                        switch (c)
                        {
                            case '\r':
                                state = Statments.enter3;
                                pos++;
                                break;
                            case ' ':
                                state = Statments.C46;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается ожидается пробел или новая строка. Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.enter3:
                        switch (c)
                        {
                            case '\n':
                                state = Statments.C47;
                                pos++;
                                break;
                        }
                        break;

                    case Statments.C46:
                        switch (c)
                        {
                            case ' ':
                                pos++;
                                break;
                            case '\r':
                                state = Statments.enter3;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась новая строка. Позиция:{1}", pos);
                                break;
                        }
                        break;

                    case Statments.C47:
                        switch (c)
                        {
                            case ' ':
                                pos++;
                                break;
                            case 'N':
                                state = Statments.C37;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"N\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C48:
                        switch (c)
                        {
                            case 'X':
                                state = Statments.C49;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"X\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C49:
                        switch (c)
                        {
                            case 'T':
                                state = Statments.C50;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Ожидалась \"T\", получено \"{0}\". Позиция:{1}", c, pos);
                                break;
                        }
                        break;

                    case Statments.C50:
                        switch (c)
                        {
                            case ' ':
                                state = Statments.C51;
                                pos++;
                                break;
                            default:
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается ожидается пробел или новая строка. Позиция:{0}", pos);
                                break;
                        }
                        break;

                    case Statments.C51:
                        if (c.Equals(' '))
                            pos++;
                        else
                            if (char.IsLetter(c))
                            {
                                state = Statments.C52;
                                identifikator.Append(c);
                                pos++;
                            }
                            else { state = Statments.ERROR; result = String.Format("Идентификатор должен начинаться с буквы. Позиция:{0}", pos); }
                        break;

                    case Statments.C52:

                        if (char.IsLetterOrDigit(c))
                        {
                            identifikator.Append(c);
                            pos++;
                        }
                        else
                            switch (c)
                            {
                                case '\r':
                                    {
                                        if (!identifikator.Equals(temp))
                                        {
                                            state = Statments.ERROR;
                                            result = String.Format("Идентификатор \"{0}\" не совпадает с изначально введенным. Позиция:{1}", identifikator, pos);
                                        }
                                        else
                                        {
                                            if (!(reserved.Contains(identifikator.ToString())) && (identifikator.Length < 9))
                                            {
                                                state = Statments.F;
                                                identifikators.Add(identifikator.ToString());
                                                identifikator.Clear();
                                                pos++;
                                            }
                                            else
                                            {
                                                state = Statments.ERROR;
                                                if (identifikators.Contains(identifikator.ToString()))
                                                    result = String.Format("Идентификатор \"{0}\" уже есть. Позиция:{1}", identifikator, pos);
                                                else if (reserved.Contains(identifikator.ToString()))
                                                    result = String.Format("Идентификатор \"{0}\" является зарезервированным словом. Позиция:{1}", identifikator, pos);
                                                else if (identifikator.Length > 8)
                                                    result = String.Format("Идентификатор \"{0}\" имеет длину больше 8 символов. Позиция:{1}", identifikator, pos);

                                            }
                                        }
                                    }
                                    break;
                                default:
                                    state = Statments.ERROR;
                                    result = String.Format("Непредвиденный символ, ожидается энтер. Позиция:{0}", pos);
                                    break;
                            }
                        break;
                            

                    case Statments.enter4:
                        switch (c)
                        {
                            case '\n':
                                state = Statments.F;
                                pos++;
                                break;
                        }
                        break;

                    case Statments.F:
                        pos++;
                        if (pos == len)
                            state = Statments.F;
                        else
                        {
                            c = inputString[pos];
                            if (!c.Equals(' '))
                            {
                                state = Statments.ERROR;
                                result = String.Format("Непредвиденный символ, ожидается enter. Позиция:{0}", pos);
                            }
                        }
                        break;


                     }
                }
                else { state = Statments.ERROR; result = "Нeпредвиденный конец строки"; }
            }
            
                    if (state == Statments.F)
                         result = "Синтаксических ошибок не обнаружено";
                    return result;   
        }



        public static string Count()
        {
            string result = null;
            if (state != Statments.F)
                result = "Имеется синтаксическая ошибка. Подсчёт невозможен";
            else
            {
                int iter = 0;
                if ((left < right && step > 0) || (left > right && step < 0))
                {
                    iter = (right - left) / step + 1;
                    result = string.Format("Количество итераций {0}", iter);
                }
                else if (step == 0)
                    result = string.Format("Количество итераций бесконечно, т.к. шаг равен 0");
                else if (left == right)
                    result = string.Format("Количество итераций 0, т.к. пределы равны друг другу");
                else if ((left < right && step < 0) || (left > right && step > 0))
                    result = string.Format("Количество итераций бесконечно, т.к. шаг имеет неверный знак");
            }
            return result;
        }
         








    }
}