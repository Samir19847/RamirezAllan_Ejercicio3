Console.WriteLine("Seleccione el tipo de cliente:");
Console.WriteLine("1. Estudiante");
Console.WriteLine("2. Docente");
Console.WriteLine("3. Administrativo");
Console.WriteLine("4. Externo");
int cliente = int.Parse(Console.ReadLine());
Console.WriteLine();
Console.WriteLine("Ingrese el monto base:");
double monto = double.Parse(Console.ReadLine());
Console.WriteLine();
Console.WriteLine("Ingrese el método de pago:");
Console.WriteLine("1. Efectivo");
Console.WriteLine("2. Tarjeta");
Console.WriteLine("3. Transferencia");
int pago = int.Parse(Console.ReadLine());
Console.WriteLine();
Console.WriteLine("¿Tiene cupón? (S/N)");
string cupon = Console.ReadLine().ToUpper();
Console.WriteLine();
double descuento = 0;
double recargos = 0;
if (cupon == "S")
{
    Console.WriteLine("Ingrese el código del cupón:");
    string codigo = Console.ReadLine();
    if (codigo.StartsWith("U"))
    {
        char ultimo = codigo[^1];
            if (char.IsDigit(ultimo))
        {
           int valor = int.Parse(ultimo.ToString());
            if (valor % 2 == 0) 
            {
                descuento = monto * valor / 100;
                Console.WriteLine($"Se aplicará un descuento del {valor}%.");
            }
            else
            {
                Console.WriteLine("El valor del cupón debe terminar en un número par. No se aplicará ningún descuento.");
            }
        }
        else
        {
            Console.WriteLine("Código de cupón inválido. No se aplicará ningún descuento.");
        }
    }


}
else
{
    Console.WriteLine("No se aplicará ningún descuento por cupón.");
}
Console.WriteLine();
Console.WriteLine("Reporte antifraude:");
Console.WriteLine("1. Ninguno");
Console.WriteLine("2. Cupón inválido repetido");
Console.WriteLine("3. Pagos rechazados múltiples");
int fraude = int.Parse(Console.ReadLine());
switch (cliente)
{
    case 1:
        if (pago == 1)
        {
            descuento = monto - (monto * 0.10);
            monto = descuento;
        }
        else if (pago == 2)
        {
            descuento = monto - (monto * 0.07);
            monto = descuento;
        }
        else if (pago == 3)
        {
            descuento = monto - (monto * 0.05);
            monto = descuento;
        }
        break;
    case 2:
        if (pago == 1)
        {
            descuento = monto - (monto * 0.07);
            monto = descuento;
        }
        else if (pago == 2)
        {
            descuento = monto - (monto * 0.05);
            monto = descuento;
        }
        else if (pago == 3)
        {
            descuento = monto - (monto * 0.03);
            monto = descuento;
        }
        break;
    case 3:
        if (pago == 1)
        {
            descuento = monto - (monto * 0.05);
            monto = descuento;

        }
        else if (pago == 2)
        {
            descuento = monto - (monto * 0.03);
            monto = descuento;
        }
        else if (pago == 3)
        {
            descuento = monto - (monto * 0.01);
            monto = descuento;
        }
        break;
    case 4:
        if (pago == 1)
        {
            descuento = monto - (monto * 0.05);
            monto = descuento;
        }
        else if (pago == 2)
        {
            descuento = monto - (monto * 0.03);
            monto = descuento;
        }
        else if (pago == 3)
        {
            descuento = monto - (monto * 0.01);
            monto = descuento;
        }
        break;
    default:
        {
            Console.WriteLine("Tipo de cliente no válido.");
        }
        break;
}
if (fraude == 2 || fraude == 3)
{
    Console.WriteLine("No se aplicará el descuento.");
    descuento = 0;
    recargos = monto + (monto * 0.20);
    monto = recargos;

}
else
{
    Console.WriteLine("Puede continuar con el proceso de pago.");
}
Console.WriteLine();
Console.WriteLine($"Descuento aplicado: {descuento:C2}");
Console.WriteLine($"Recargos aplicados: {recargos:C2}");
Console.WriteLine($"Monto final a pagar: {monto:C2}");
