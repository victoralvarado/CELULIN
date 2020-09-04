using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;

namespace Celulin2._0
{
    class Program
    {
        // codigo para maximizar consola
        [DllImport("kernel32.dll", ExactSpelling = true)]                          // codigo para maximizar consola
        private static extern IntPtr GetConsoleWindow();                           // https://www.c-sharpcorner.com/code/448/code-to-auto-maximize-console-application-according-to-screen-width-in-c-sharp.aspx
        private static IntPtr ThisConsole = GetConsoleWindow();
        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]     //
        private static extern bool ShowWindow(IntPtr hWnd, int nCmdShow);          //
        private const int HIDE = 0;                                                //
        private const int MAXIMIZE = 3;                                            //
        private const int MINIMIZE = 6;                                            //
        private const int RESTORE = 9;                                             //
        // fin codigo para maximizar consola
        static void Main()
        {
            // codigo para maximizar consola
            Console.SetWindowSize(Console.LargestWindowWidth, Console.LargestWindowHeight);
            ShowWindow(ThisConsole, MAXIMIZE);
            // fin codigo para maximizar consol

            string valOpcionSalir;
            int opcionSalir;
            string numModi;
            string numEli;
            string numTemporal;
            string apeTemporal;
            string nomTemporal;
            string dirTemporal;
            string valOpcionM;
            string validaropcion;
            string valOpModi;
            string valOpComp;
            string ValOpcionP;
            string[] modelocel = new string[1000];
            string[] nombrePropie = new string[1000];
            string[] apellidos = new string[1000];
            string[] direccion = new string[1000];
            string[] numeroDeTelefono = new string[1000];
            string[] nombreCompany = new string[1000];
            string[] plan = new string[1000];
            double[] pagoMen = new double[1000];
            int i;
            int j;
            int k;
            int opcion;
            int opcionComp;
            int opcionM;
            int opcionP;
            int opModi;
            int indice = 0;
            bool validard;
            bool validar;



            Regex rgxTelefono = new Regex(@"^[67]{1}[0-9]{7}$");//Formato numero de telefono
            Regex rgxNomApe = new Regex(@"^[a-zñA-ZÑ ]+$");
            Regex regex = new Regex(@"[ ]{2,}");//quitar espacios de mas y dejar solo uno etre cadenas
            char[] charsToTrim = { ' ' };
            string result;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("       ┌───┬───┬┐  ┌┐ ┌┬┐  ┌──┬─┐ ┌┐┌───┐┌───┐┌───┬───┐┌───┬┐  ┌┐");
            Console.WriteLine("       │┌─┐│┌──┤│  ││ │││  └┤├┤│└┐│││┌─┐││┌─┐│└┐┌┐│┌──┘│┌─┐│└┐┌┘│");
            Console.WriteLine("       ││ └┤└──┤│  ││ │││   │││┌┐└┘││└──┐││ ││ ││││└──┐││ └┴┐││┌┘");
            Console.WriteLine("       ││ ┌┤┌──┤│ ┌┤│ │││ ┌┐││││└┐││└──┐││└─┘│ ││││┌──┘││ ┌┐│└┘│ ");
            Console.WriteLine("       │└─┘│└──┤└─┘│└─┘│└─┘├┤├┤│ ││││└─┘├┤┌─┐│┌┘└┘│└──┐│└─┘├┼┐┌┘ ");
            Console.WriteLine("       └───┴───┴───┴───┴───┴──┴┘ └─┘└───┴┴┘ └┘└───┴───┘└───┴┘└┘  ");
            Console.ResetColor();
            do
            {
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│                                 MENÚ                                │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘");
                Console.WriteLine("┌─────────────────────────────────────────────────────────────────────┐");
                Console.WriteLine("│                    1. Ingresar un nuevo cliente                     │");
                Console.WriteLine("│                    2. Modificar los datos de un usuario             │");
                Console.WriteLine("│                    3. Eliminar los datos de un usuario              │");
                Console.WriteLine("│                    4. Mostrar el listado de los datos               │");
                Console.WriteLine("│                    5. Salir                                         │");
                Console.WriteLine("└─────────────────────────────────────────────────────────────────────┘");
                Console.Write("Seleccione el número de la actividad a realizar: ");
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                validaropcion = Console.ReadLine();
                Console.ResetColor();
                if (int.TryParse(validaropcion, out opcion))//convertir validarOpcion a entero si se convierte devuelve True
                {

                    switch (opcion)
                    {
                        case 1:
                            if (indice > numeroDeTelefono.Length - 1)
                            {
                                Console.WriteLine("memoria llena, ya no puede registrar mas Clientes");
                            }
                            else
                            {
                                Console.WriteLine();
                                Console.ForegroundColor = ConsoleColor.DarkGreen;
                                Console.WriteLine("             Bienvenido a telefonia CELULIN.");
                                Console.WriteLine("Por favor ingrese los datos que se le solicitan a continuación");
                                Console.ResetColor();

                                do
                                {
                                    validar = false;
                                    Console.Write("Ingrese el numero de telefono asignado: ");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    numTemporal = Console.ReadLine();
                                    Console.ResetColor();
                                    for (i = 0; i < indice; i++)
                                    {

                                        if (numeroDeTelefono[i] == numTemporal)
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("El numero que ingreso se encuentra registrado");
                                            Console.ResetColor();
                                            validar = true;
                                        }
                                    }
                                    if (validar == false)
                                    {
                                        if (rgxTelefono.IsMatch(numTemporal))
                                        {
                                            numeroDeTelefono[indice] = numTemporal;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("el numero no contiene el formato correcto!!");
                                            Console.WriteLine("(Debe ingresar '8' digitos, el primer digito debe empezar con '7' o con '6')");
                                            Console.ResetColor();
                                            validar = true;
                                        }

                                    }
                                } while (validar != false);
                                do
                                {
                                    validar = false;
                                    Console.WriteLine();
                                    Console.WriteLine("Por favor selecione la compañia a la que desea permanecer: ");
                                    Console.WriteLine("1. Claro.");
                                    Console.WriteLine("2. Tigo.");
                                    Console.WriteLine("3. Movistar.");
                                    Console.WriteLine("4. Digicel.");
                                    Console.Write("Digite la opción: ");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    valOpComp = Console.ReadLine();
                                    if (int.TryParse(valOpComp, out opcionComp))
                                    {

                                        Console.ResetColor();
                                        switch (opcionComp)
                                        {
                                            case 1:
                                                nombreCompany[indice] = "Claro";
                                                validar = false;
                                                break;
                                            case 2:
                                                nombreCompany[indice] = "Tigo";
                                                validar = false;
                                                break;
                                            case 3:
                                                nombreCompany[indice] = "Movistar";
                                                validar = false;
                                                break;
                                            case 4:
                                                nombreCompany[indice] = "Digicel";
                                                validar = false;
                                                break;
                                            default:
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("la opcion '{0}' no se encuentra en el menu!", opcionComp);
                                                Console.ResetColor();
                                                validar = true;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("El valor ingresado no es correcto!");
                                        Console.ResetColor();
                                        validar = true;
                                    }

                                } while (validar != false);

                                do
                                {
                                    validar = false;
                                    Console.WriteLine();
                                    Console.WriteLine("Por favor selecione el modelo de teléfono que desea:");
                                    Console.WriteLine("1. Samsung S10+ ($594).");
                                    Console.WriteLine("2. Huawei P30 light ($350).");
                                    Console.WriteLine("3. Iphone Xs Max ($1200).");
                                    Console.WriteLine("4. Xhiomi ($250).");
                                    Console.WriteLine("5. LG K11 ($250)");
                                    Console.WriteLine("6. Sony Xperia ($300)");
                                    Console.Write("Digite la opción: ");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    valOpcionM = Console.ReadLine();
                                    if (int.TryParse(valOpcionM, out opcionM))
                                    {

                                        switch (opcionM)
                                        {
                                            case 1:
                                                modelocel[indice] = "Samsung S10+ ($594).";
                                                validar = false;
                                                break;
                                            case 2:
                                                modelocel[indice] = "Huawei P30 light ($350).";
                                                validar = false;
                                                break;
                                            case 3:
                                                modelocel[indice] = "Iphone Xs Max ($1200).";
                                                validar = false;
                                                break;
                                            case 4:
                                                modelocel[indice] = "Xhiomi ($250).";
                                                validar = false;
                                                break;
                                            case 5:
                                                modelocel[indice] = "LG K11 ($250).";
                                                validar = false;
                                                break;
                                            case 6:
                                                modelocel[indice] = "Sony Xperia ($300).";
                                                validar = false;
                                                break;
                                            default:
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("la opcion '{0}' no se encuentra en el menu!", opcionM);
                                                Console.ResetColor();
                                                validar = true;
                                                break;
                                        }

                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("El valor ingresado no es correcto!");
                                        Console.ResetColor();
                                        validar = true;
                                    }

                                } while (validar != false);
                                Console.ResetColor();
                                do
                                {
                                    validar = false;
                                    Console.Write("Apellidos del cliente: ");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    apeTemporal = Console.ReadLine();
                                    Console.ResetColor();
                                    if (apeTemporal.Trim() == "")//validar caracteres de espacios en blanco iniciales y finales del String actual
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("debe ingresar los apellidos");
                                        Console.ResetColor();
                                        validar = true;
                                    }
                                    else
                                    {
                                        if (rgxNomApe.IsMatch(apeTemporal))
                                        {
                                            result = apeTemporal.Trim(charsToTrim);
                                            string result2 = regex.Replace(apeTemporal, @" ");//quitar espacios de mas y dejar solo uno etre cadenas
                                            apellidos[indice] = result2;
                                            validar = false;

                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("debe ingresar solo letras");
                                            Console.ResetColor();
                                            validar = true;
                                        }

                                    }
                                } while (validar != false);
                                do
                                {
                                    validar = false;
                                    Console.Write("Nombres del cliente: ");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    nomTemporal = Console.ReadLine();
                                    Console.ResetColor();
                                    if (nomTemporal.Trim() == "")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("debe ingresar los nombres");
                                        Console.ResetColor();
                                        validar = true;
                                    }
                                    else
                                    {
                                        if (rgxNomApe.IsMatch(nomTemporal))
                                        {
                                            result = nomTemporal.Trim(charsToTrim);
                                            string result2 = regex.Replace(nomTemporal, @" ");//quitar espacios de mas y dejar solo uno etre cadenas
                                            nombrePropie[indice] = result2;
                                            validar = false;
                                        }
                                        else
                                        {
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("debe ingresar solo letras");
                                            Console.ResetColor();
                                            validar = true;
                                        }

                                    }
                                } while (validar != false);
                                do
                                {
                                    validar = false;
                                    Console.Write("Direccion: ");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    dirTemporal = Console.ReadLine();
                                    Console.ResetColor();
                                    if (dirTemporal.Trim() == "")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                        Console.WriteLine("debe ingresar una direccion");
                                        Console.ResetColor();
                                        validar = true;
                                    }
                                    else
                                    {
                                        result = dirTemporal.Trim(charsToTrim);
                                        string result2 = regex.Replace(dirTemporal, @" ");//quitar espacios de mas y dejar solo uno etre cadenas
                                        direccion[indice] = result2;
                                        validar = false;
                                    }
                                } while (validar != false);
                                do
                                {
                                    validar = false;
                                    Console.WriteLine();
                                    Console.WriteLine("Especifique el tipo de plan: ");
                                    Console.WriteLine("1. Prepago.");
                                    Console.WriteLine("2. Pospago.");
                                    Console.Write("Ingrese la opcion seleccionada: ");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    ValOpcionP = Console.ReadLine();
                                    Console.ResetColor();
                                    if (int.TryParse(ValOpcionP, out opcionP))
                                    {

                                        switch (opcionP)
                                        {
                                            case 1:
                                                plan[indice] = "Prepago";
                                                pagoMen[indice] = 0.0;
                                                Console.WriteLine();
                                                Console.WriteLine("se pagara $0.00 ");
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Su registro ha finalizado.");
                                                Console.ResetColor();
                                                validar = false;
                                                break;
                                            case 2:
                                                plan[indice] = "Pospago";
                                                pagoMen[indice] = 25.0;
                                                Console.WriteLine();
                                                Console.WriteLine("Se pagara $25 mensual.");
                                                Console.Clear();
                                                Console.ForegroundColor = ConsoleColor.Green;
                                                Console.WriteLine("Su registro ha finalizado.");
                                                Console.ResetColor();
                                                validar = false;
                                                break;
                                            default:
                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                Console.WriteLine("la opcion '{0}' no se encuentra en el menu!", opcionP);
                                                Console.ResetColor();
                                                validar = true;
                                                break;
                                        }
                                    }
                                    else
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.WriteLine("El valor ingresado no es correcto!");
                                        Console.ResetColor();
                                        validar = true;
                                    }

                                } while (validar != false);
                                indice++;

                            }
                            break;
                        case 2:
                            if (indice > 0)
                            {
                                bool existe = false;
                                Console.WriteLine("ingrese el numero de telefono del cliente que desea modificar");

                                numModi = Console.ReadLine();
                                for (i = 0; i < numeroDeTelefono.Length; i++)
                                {
                                    do
                                    {
                                        validard = false;
                                        if (numeroDeTelefono[i] == numModi)
                                        {
                                            existe = true;
                                            Console.WriteLine("===============DATOS ACTUALES============");
                                            Console.WriteLine("1. Numero de telefono: {0}", numeroDeTelefono[i]);
                                            Console.WriteLine("2. Nombre de la compania: {0}", nombreCompany[i]);
                                            Console.WriteLine("3. Modelo del telefono: {0}", modelocel[i]);
                                            Console.WriteLine("4. Apellidos del propietario: {0}", apellidos[i]);
                                            Console.WriteLine("5. Nombres del propietario: {0}", nombrePropie[i]);
                                            Console.WriteLine("6. Direccion del propietario: {0}", direccion[i]);
                                            Console.WriteLine("7. Tipo de plan: {0}", plan[i]);
                                            Console.WriteLine("=========================================");
                                            Console.WriteLine("Ingrese el número de la opción del dato a modificar");
                                            valOpModi = Console.ReadLine();
                                            if (int.TryParse(valOpModi, out opModi))
                                            {
                                                switch (opModi)
                                                {
                                                    case 1:
                                                        do
                                                        {
                                                            validar = false;
                                                            Console.WriteLine("Escribe el nuevo numero del cliente");
                                                            numTemporal = Console.ReadLine();
                                                            for (int c = 0; c < numeroDeTelefono.Length; c++)
                                                            {

                                                                if (numeroDeTelefono[c] == numTemporal)
                                                                {
                                                                    if (numModi == numTemporal)
                                                                    {
                                                                        validar = false;
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine("El numero que ingreso se encuentra registrado");
                                                                        validar = true;
                                                                    }

                                                                }
                                                            }
                                                            if (validar == false)
                                                            {
                                                                if (rgxTelefono.IsMatch(numTemporal))
                                                                {
                                                                    numeroDeTelefono[i] = numTemporal;
                                                                    validard = false;
                                                                }
                                                                else
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine("el numero no contiene el formato correcto!!");
                                                                    Console.WriteLine("(Debe ingresar '8' digitos, el primer digito debe empezar con '7' o con '6')");
                                                                    Console.ResetColor();
                                                                    validar = true;
                                                                }

                                                            }


                                                        } while (validar != false);
                                                        break;
                                                    case 2:
                                                        do
                                                        {
                                                            validar = false;
                                                            Console.WriteLine();
                                                            Console.WriteLine("Por favor selecione la compañia a la que desea permanecer: ");
                                                            Console.WriteLine("1. Claro.");
                                                            Console.WriteLine("2. Tigo.");
                                                            Console.WriteLine("3. Movistar.");
                                                            Console.WriteLine("4. Digicel.");
                                                            Console.Write("Digite la opción: ");
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            valOpComp = Console.ReadLine();
                                                            if (int.TryParse(valOpComp, out opcionComp))
                                                            {

                                                                Console.ResetColor();
                                                                switch (opcionComp)
                                                                {
                                                                    case 1:
                                                                        nombreCompany[i] = "Claro";
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.WriteLine("su registro se ha modificado");
                                                                        Console.ResetColor();
                                                                        validar = false;
                                                                        break;
                                                                    case 2:
                                                                        nombreCompany[i] = "Tigo";
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.WriteLine("su registro se ha modificado");
                                                                        Console.ResetColor();
                                                                        validar = false;
                                                                        break;
                                                                    case 3:
                                                                        nombreCompany[i] = "Movistar";
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.WriteLine("su registro se ha modificado");
                                                                        Console.ResetColor();
                                                                        validar = false;
                                                                        break;
                                                                    case 4:
                                                                        nombreCompany[i] = "Digicel";
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.WriteLine("su registro se ha modificado");
                                                                        Console.ResetColor();
                                                                        validar = false;
                                                                        break;
                                                                    default:
                                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                                        Console.WriteLine("la opcion '{0}' no se encuentra en el menu!", opcionComp);
                                                                        Console.ResetColor();
                                                                        validar = true;
                                                                        break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("El valor ingresado no es correcto!");
                                                                Console.ResetColor();
                                                                validar = true;
                                                            }

                                                        } while (validar != false);
                                                        break;
                                                    case 3:
                                                        do
                                                        {
                                                            validar = false;
                                                            Console.WriteLine();
                                                            Console.WriteLine("Por favor selecione el modelo de teléfono que desea:");
                                                            Console.WriteLine("1. Samsung S10+ ($594).");
                                                            Console.WriteLine("2. Huawei P30 light ($350).");
                                                            Console.WriteLine("3. Iphone Xs Max ($1200).");
                                                            Console.WriteLine("4. Xhiomi ($250).");
                                                            Console.WriteLine("5. LG K11 ($250)");
                                                            Console.WriteLine("6. Sony Xperia ($300)");
                                                            Console.Write("Digite la opción: ");
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            valOpcionM = Console.ReadLine();
                                                            if (int.TryParse(valOpcionM, out opcionM))
                                                            {

                                                                switch (opcionM)
                                                                {
                                                                    case 1:
                                                                        modelocel[i] = "Samsung S10+ ($594).";
                                                                        validar = false;
                                                                        break;
                                                                    case 2:
                                                                        modelocel[i] = "Huawei P30 light ($350).";
                                                                        validar = false;
                                                                        break;
                                                                    case 3:
                                                                        modelocel[i] = "Iphone Xs Max ($1200).";
                                                                        validar = false;
                                                                        break;
                                                                    case 4:
                                                                        modelocel[i] = "Xhiomi ($250).";
                                                                        validar = false;
                                                                        break;
                                                                    case 5:
                                                                        modelocel[i] = "LG K11 ($250).";
                                                                        validar = false;
                                                                        break;
                                                                    case 6:
                                                                        modelocel[i] = "Sony Xperia ($300).";
                                                                        validar = false;
                                                                        break;
                                                                    default:
                                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                                        Console.WriteLine("la opcion '{0}' no se encuentra en el menu!", opcionM);
                                                                        Console.ResetColor();
                                                                        validar = true;
                                                                        break;
                                                                }

                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("El valor ingresado no es correcto!");
                                                                Console.ResetColor();
                                                                validar = true;
                                                            }

                                                        } while (validar != false);
                                                        break;
                                                    case 4:
                                                        do
                                                        {
                                                            validar = false;
                                                            Console.Write("Apellidos del cliente: ");
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            apeTemporal = Console.ReadLine();
                                                            Console.ResetColor();
                                                            if (apeTemporal.Trim() == "")//validar caracteres de espacios en blanco iniciales y finales del String actual
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine("debe ingresar los apellidos");
                                                                Console.ResetColor();
                                                                validar = true;
                                                            }
                                                            else
                                                            {
                                                                if (rgxNomApe.IsMatch(apeTemporal))
                                                                {
                                                                    validar = false;
                                                                    apellidos[i] = apeTemporal;
                                                                    Console.Clear();
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine("Su registro se ha modificado.");
                                                                    Console.ResetColor();
                                                                }
                                                                else
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine("debe ingresar solo letras");
                                                                    Console.ResetColor();
                                                                    validar = true;
                                                                }
                                                            }
                                                        } while (validar != false);
                                                        break;
                                                    case 5:
                                                        do
                                                        {
                                                            validar = false;
                                                            Console.Write("Nombres del cliente: ");
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            nomTemporal = Console.ReadLine();
                                                            Console.ResetColor();
                                                            if (nomTemporal.Trim() == "")
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine("debe ingresar los nombres");
                                                                Console.ResetColor();
                                                                validar = true;
                                                            }
                                                            else
                                                            {
                                                                if (rgxNomApe.IsMatch(nomTemporal))
                                                                {
                                                                    validar = false;
                                                                    nombrePropie[i] = nomTemporal;
                                                                    Console.Clear();
                                                                    Console.ForegroundColor = ConsoleColor.Green;
                                                                    Console.WriteLine("Su registro se ha modificado.");
                                                                    Console.ResetColor();
                                                                }
                                                                else
                                                                {
                                                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                                                    Console.WriteLine("debe ingresar solo letras");
                                                                    Console.ResetColor();
                                                                    validar = true;
                                                                }
                                                            }
                                                        } while (validar != false);
                                                        break;
                                                    case 6:
                                                        do
                                                        {
                                                            validar = false;
                                                            Console.Write("Direccion: ");
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            dirTemporal = Console.ReadLine();
                                                            Console.ResetColor();
                                                            if (dirTemporal.Trim() == "")
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Yellow;
                                                                Console.WriteLine("debe ingresar una direccion");
                                                                Console.ResetColor();
                                                                validar = true;
                                                            }
                                                            else
                                                            {
                                                                validar = false;
                                                                direccion[i] = dirTemporal;
                                                                Console.Clear();
                                                                Console.ForegroundColor = ConsoleColor.Green;
                                                                Console.WriteLine("Su registro se ha modificado.");
                                                                Console.ResetColor();
                                                            }
                                                        } while (validar != false);
                                                        break;
                                                    case 7:
                                                        do
                                                        {
                                                            validar = false;
                                                            Console.WriteLine();
                                                            Console.WriteLine("Especifique el tipo de plan: ");
                                                            Console.WriteLine("1. Prepago.");
                                                            Console.WriteLine("2. Pospago.");
                                                            Console.Write("Ingrese la opcion seleccionada: ");
                                                            Console.ForegroundColor = ConsoleColor.DarkCyan;
                                                            ValOpcionP = Console.ReadLine();
                                                            Console.ResetColor();
                                                            if (int.TryParse(ValOpcionP, out opcionP))
                                                            {

                                                                switch (opcionP)
                                                                {
                                                                    case 1:
                                                                        plan[i] = "Prepago";
                                                                        pagoMen[i] = 0.0;
                                                                        Console.WriteLine();
                                                                        Console.WriteLine("se pagara $0.00 ");
                                                                        Console.Clear();
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.WriteLine("Su registro se ha modificado.");
                                                                        Console.ResetColor();
                                                                        validar = false;
                                                                        break;
                                                                    case 2:
                                                                        plan[i] = "Pospago";
                                                                        pagoMen[i] = 25.0;
                                                                        Console.WriteLine();
                                                                        Console.WriteLine("Se pagara $25 mensual.");
                                                                        Console.Clear();
                                                                        Console.ForegroundColor = ConsoleColor.Green;
                                                                        Console.WriteLine("Su registro se ha modificado.");
                                                                        Console.ResetColor();
                                                                        validar = false;
                                                                        break;
                                                                    default:
                                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                                        Console.WriteLine("la opcion '{0}' no se encuentra en el menu!", opcionP);
                                                                        Console.ResetColor();
                                                                        validar = true;
                                                                        break;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                Console.ForegroundColor = ConsoleColor.Red;
                                                                Console.WriteLine("El valor ingresado no es correcto!");
                                                                Console.ResetColor();
                                                                validar = true;
                                                            }

                                                        } while (validar != false);
                                                        break;
                                                    default:
                                                        Console.ForegroundColor = ConsoleColor.Yellow;
                                                        Console.WriteLine("la opcion '{0}' no se encuetra en el menu", opModi);
                                                        Console.ResetColor();
                                                        validar = false;
                                                        break;
                                                }
                                            }
                                            else
                                            {
                                                Console.ForegroundColor = ConsoleColor.Red;
                                                Console.WriteLine("El valor ingresado no es correcto!");
                                                Console.ResetColor();
                                            }
                                        }
                                    } while (validard != false);

                                }
                                if (!existe)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("No se encontró el cliente!!");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("No hay clientes registrados!!");
                                Console.ResetColor();
                            }
                            break;
                        case 3:
                            if (indice > 0)
                            {
                                bool existe = false;
                                Console.WriteLine("ingrese el numero del cliente que desea eliminar");
                                numEli = Console.ReadLine();
                                for (i = 0; i < numeroDeTelefono.Length; i++)
                                {
                                    if (numeroDeTelefono[i] == numEli)
                                    {
                                        existe = true;
                                        for (j = i; j < indice - 1; j++)
                                        {
                                            numeroDeTelefono[j] = numeroDeTelefono[j + 1];
                                        }
                                        indice--;
                                        Console.WriteLine("El cliente se ha eliminado");
                                    }
                                }
                                if (!existe)
                                {
                                    Console.Clear();
                                    Console.ForegroundColor = ConsoleColor.Yellow;
                                    Console.WriteLine("No se encontró el cliente!!");
                                    Console.ResetColor();
                                }
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("No hay clientes registrados!!");
                                Console.ResetColor();
                            }
                            break;
                        case 4:
                            try
                            {

                            
                            if (indice > 0)

                            {
                                for (j = 0; j < indice - 1; j++)
                                {
                                    for (k = 0; k < indice - 1; k++)
                                    {
                                        if (nombreCompany[k].CompareTo(nombreCompany[k + 1]) > 0)
                                        {
                                            string auxNT = numeroDeTelefono[k];
                                            numeroDeTelefono[k] = numeroDeTelefono[k + 1];
                                            numeroDeTelefono[k + 1] = auxNT;

                                            string auxNC = nombreCompany[k];
                                            nombreCompany[k] = nombreCompany[k + 1];
                                            nombreCompany[k + 1] = auxNC;

                                            string auxMC = modelocel[k];
                                            modelocel[k] = modelocel[k + 1];
                                            modelocel[k + 1] = auxMC;

                                            string auxN = nombrePropie[k];
                                            nombrePropie[k] = nombrePropie[k + 1];
                                            nombrePropie[k + 1] = auxN;

                                            string auxA = apellidos[k];
                                            apellidos[k] = apellidos[k + 1];
                                            apellidos[k + 1] = auxA;

                                            string auxD = direccion[k];
                                            direccion[k] = direccion[k + 1];
                                            direccion[k + 1] = auxD;

                                            string auxP = plan[k];
                                            plan[k] = plan[k + 1];
                                            plan[k + 1] = auxP;

                                            double auxPM = pagoMen[k];
                                            pagoMen[k] = pagoMen[k + 1];
                                            pagoMen[k + 1] = auxPM;
                                        }
                                    }
                                }

                                for (j = 0; j < indice - 1; j++)
                                {
                                    for (k = 0; k < indice - 1; k++)
                                    {

                                        if (nombreCompany[k] == nombreCompany[k + 1] && (apellidos[k] + "" + nombrePropie[k]).CompareTo(apellidos[k + 1] + "" + nombrePropie[k + 1]) > 0)
                                        {
                                            string auxNT = numeroDeTelefono[k];
                                            numeroDeTelefono[k] = numeroDeTelefono[k + 1];
                                            numeroDeTelefono[k + 1] = auxNT;

                                            string auxNC = nombreCompany[k];
                                            nombreCompany[k] = nombreCompany[k + 1];
                                            nombreCompany[k + 1] = auxNC;

                                            string auxMC = modelocel[k];
                                            modelocel[k] = modelocel[k + 1];
                                            modelocel[k + 1] = auxMC;

                                            string auxN = nombrePropie[k];
                                            nombrePropie[k] = nombrePropie[k + 1];
                                            nombrePropie[k + 1] = auxN;

                                            string auxA = apellidos[k];
                                            apellidos[k] = apellidos[k + 1];
                                            apellidos[k + 1] = auxA;

                                            string auxD = direccion[k];
                                            direccion[k] = direccion[k + 1];
                                            direccion[k + 1] = auxD;

                                            string auxP = plan[k];
                                            plan[k] = plan[k + 1];
                                            plan[k + 1] = auxP;

                                            double auxPM = pagoMen[k];
                                            pagoMen[k] = pagoMen[k + 1];
                                            pagoMen[k + 1] = auxPM;
                                        }
                                    }
                                }
                                Console.Clear();
                                for (i = 0; i < indice; i++)
                                {

                                    Console.SetCursorPosition(0, 0);
                                    Console.WriteLine("=========================================================================== REGISTROS ==================================================================");
                                    Console.ForegroundColor = ConsoleColor.DarkCyan;
                                    Console.SetCursorPosition(0, 1);
                                    Console.Write("Numero de telefono");
                                    Console.SetCursorPosition(20, 1);
                                    Console.Write("Nombre Compañia");
                                    Console.SetCursorPosition(40, 1);
                                    Console.Write("Modelo Celular y precio");
                                    Console.SetCursorPosition(70, 1);
                                    Console.Write("Nombre propietario");
                                    Console.SetCursorPosition(105, 1);
                                    Console.Write("Direccion");
                                    Console.SetCursorPosition(120, 1);
                                    Console.Write("Plan");
                                    Console.SetCursorPosition(135, 1);
                                    Console.Write("Pago mensual");
                                    Console.ResetColor();
                                    
                                    Console.SetCursorPosition(0, 2 + i);
                                    Console.WriteLine(numeroDeTelefono[i]);
                                    if (nombreCompany[i] == "Claro")
                                    {
                                        Console.ForegroundColor = ConsoleColor.DarkRed;
                                        Console.SetCursorPosition(20, 2 + i);
                                        Console.WriteLine(nombreCompany[i]);
                                        Console.ResetColor();
                                    }
                                    if (nombreCompany[i] == "Tigo")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Blue;
                                        Console.SetCursorPosition(20, 2 + i);
                                        Console.WriteLine(nombreCompany[i]);
                                        Console.ResetColor();
                                    }
                                    if (nombreCompany[i] == "Movistar")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Green;
                                        Console.SetCursorPosition(20, 2 + i);
                                        Console.WriteLine(nombreCompany[i]);
                                        Console.ResetColor();
                                    }
                                    if (nombreCompany[i] == "Digicel")
                                    {
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.SetCursorPosition(20, 2 + i);
                                        Console.WriteLine(nombreCompany[i]);
                                        Console.ResetColor();
                                    }

                                    Console.SetCursorPosition(40, 2 + i);
                                    Console.WriteLine(modelocel[i]);
                                    Console.SetCursorPosition(70, 2 + i);
                                    Console.WriteLine(apellidos[i] + " " + nombrePropie[i]);
                                    Console.SetCursorPosition(105, 2 + i);
                                    Console.WriteLine(direccion[i]);
                                    Console.SetCursorPosition(120, 2 + i);
                                    Console.WriteLine(plan[i]);
                                    Console.SetCursorPosition(135, 2 + i);
                                    Console.WriteLine("${0}",pagoMen[i]);

                                }
                                Console.WriteLine("========================================================================================================================================================");
                            }
                            else
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Yellow;
                                Console.WriteLine("No hay clientes registrados");
                                Console.ResetColor();
                            }
                            }
                            catch (Exception)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.WriteLine("la pantalla debe estar maximizada para mostrar los registros");
                                Console.ResetColor();
                            }
                            break;
                        case 5:


                            do
                            {
                                opcionSalir = 0;
                                Console.WriteLine("esta seguro que desea salir?");
                                Console.WriteLine("1. SI");
                                Console.WriteLine("2. NO");
                                valOpcionSalir = Console.ReadLine();
                                if (int.TryParse(valOpcionSalir, out opcionSalir))
                                {
                                    switch (opcionSalir)
                                    {
                                        case 1:
                                            Environment.Exit(0);
                                            break;
                                        case 2:
                                            Console.Clear();
                                            Main();
                                            break;
                                        default:
                                            Console.ForegroundColor = ConsoleColor.Yellow;
                                            Console.WriteLine("la opcion '{0}' no se encuentra en el menu!", opcionSalir);
                                            Console.ResetColor();
                                            break;
                                    }
                                }
                                else
                                {
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.WriteLine("El valor ingresado no es correcto!");
                                    Console.ResetColor();
                                }
                            } while (opcionSalir != 1);
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Yellow;
                            Console.WriteLine("la opcion '{0}' no se encuentra en el menu!", opcion);
                            Console.ResetColor();
                            break;
                    }
                }
                else
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("El valor ingresado no es correcto!");
                    Console.ResetColor();
                }
            } while (opcion != 5);
        }
    }
}
