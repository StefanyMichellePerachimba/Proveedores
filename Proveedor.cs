using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace ConsoleApp6
{
    internal class Proveedor : Item
    {
        public string RUC;
        public string Razon_Social;
        public string Direccion;
        public string Ciudad;
        public string Telefono;


        public Proveedor(Consola _consola, BaseDatos _objBD) : base(_consola, _objBD, "000", "Proveedor", "Cédula")
        {
        }

        public Proveedor(Consola _consola, BaseDatos _objBD, string _Codigo,
             string RUC, string Razon_Social, string Direccion, string Ciudad, string Telefono)
            : base(_consola, _objBD, _Codigo, "Proveedor", "Cédula")
        {
            
            this.RUC = RUC;
            this.Razon_Social = Razon_Social;
            this.Direccion = Direccion;
            this.Ciudad = Ciudad;
            this.Telefono = Telefono;

        }

        public override Item creatItem(Consola _consola, BaseDatos _objBD)
        {
            return new Proveedor(_consola, _objBD);
        }

        public override Item creatItem(Consola _consola, BaseDatos _objBD, DataRow _registro)
        {

            return new Proveedor(_consola, _objBD, _registro["ID"].ToString(),
                  _registro["RUC"].ToString(), _registro["Razon_Social"].ToString(), _registro["Direccion"].ToString(),
                   _registro["Ciudad"].ToString(), _registro["Telefono"].ToString());
        }

        public override void mostrarMembreteTabla()
        {
            consola.Escribir(40, 2, ConsoleColor.Yellow, "LISTA DE PROVEEDORES");
            consola.Escribir(5, 5, ConsoleColor.Blue, "N°"); consola.Escribir(10, 5, ConsoleColor.Blue, "ID");
            consola.Escribir(30, 5, ConsoleColor.Blue, "RUC"); consola.Escribir(60, 5, ConsoleColor.Blue, "Razon_Social");
            consola.Escribir(70, 5, ConsoleColor.Blue, "Dirección"); consola.Escribir(80, 5, ConsoleColor.Blue, "Ciudad");
            consola.Escribir(90, 5, ConsoleColor.Blue, "Telefono");
            consola.Marco(3, 4, 95, 15);
        }

        public override void mostrarInfoComoFila(int Num, int fila)
        {
            consola.Escribir(5, fila, ConsoleColor.White, Num.ToString());
            consola.Escribir(10, fila, ConsoleColor.White, Codigo);
            consola.Escribir(25, fila, ConsoleColor.White, RUC);
            consola.Escribir(55, fila, ConsoleColor.White, Razon_Social);
            consola.Escribir(65, fila, ConsoleColor.White, Direccion);
            consola.Escribir(75, fila, ConsoleColor.White, Ciudad);
            consola.Escribir(85, fila, ConsoleColor.White, Telefono);
        }


        public override void mostrarInfo()
        {

            consola.Escribir(30, 2, ConsoleColor.Red, "INFORMACIÓN DEL PROVEEDOR");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "ID: "); consola.Escribir(35, 5, ConsoleColor.White,Codigo );
            consola.Escribir(20, 6, ConsoleColor.Yellow, "RUC "); consola.Escribir(35, 6, ConsoleColor.White, RUC);
            consola.Escribir(20, 7, ConsoleColor.Yellow, "Razon_Social: "); consola.Escribir(35, 7, ConsoleColor.White, Razon_Social);
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Direccion: "); consola.Escribir(35, 8, ConsoleColor.White, Direccion);
           consola.Escribir(20, 9, ConsoleColor.Yellow, "Cuidad: "); consola.Escribir(35, 9, ConsoleColor.White, Ciudad);
            consola.Escribir(20, 10, ConsoleColor.Yellow, "Telefono: "); consola.Escribir(35, 10, ConsoleColor.White, Telefono);

        }

        public override void leerInfo()
        {

            consola.Escribir(30, 2, ConsoleColor.Red, "NUEVO PROVEEDOR");
            consola.Marco(10, 3, 65, 11);
            consola.Escribir(20, 5, ConsoleColor.Yellow, "ID: ");
            consola.Escribir(20, 6, ConsoleColor.Yellow, "RUC: ");
            consola.Escribir(20, 7, ConsoleColor.Yellow, "Razon_Social: ");
            consola.Escribir(20, 8, ConsoleColor.Yellow, "Direccion: ");
            consola.Escribir(20, 9, ConsoleColor.Yellow, "Cuidad: ");
            consola.Escribir(20, 10, ConsoleColor.Yellow, "Telefono: ");
            Codigo = consola.leerCadena(35, 5);
            RUC = consola.leerCadena(35, 6);
            Razon_Social = consola.leerCadena(35, 7);
            Direccion = consola.leerCadena(35, 8);
            Ciudad = consola.leerCadena(35, 9);
            Telefono = consola.leerCadena(35, 10);


        }

        public override String getSQL(String TipoSQL, String CodigoABuscar = "")
        {
            String SQL = "";
            switch (TipoSQL)
            {
                case "Insert":
                    SQL = "Insert into TbProveedores (RUC, RazonSocial,Direccion,Ciudad,Telefono) values('"
                      + RUC + "','" + Razon_Social + "','" + Direccion + "','" + Ciudad + "','" + Telefono + "');";
                    break;
                case "Delete":
                    SQL = "Delete from TbProveedores where RUC='" + CodigoABuscar + "'";
                    break;
                case "Select":
                    if (CodigoABuscar != "")
                    {
                        SQL = "Select * from TbProveedores where RUC='" + CodigoABuscar + "'";
                    }
                    else
                    {
                        SQL = "Select * from TbProveedores order by RUC";

                    }
                    break;
            }

            return SQL;


        }
    }
    }
