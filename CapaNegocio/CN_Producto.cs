﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using CapaEntidad;
namespace CapaNegocio
{
    public class CN_Producto
    {



        private CD_Producto objCapaDato = new CD_Producto();

        public List<Producto> Listar()
        {
            return objCapaDato.Listar();
        }


        public int Registrar(Producto obj, out string Mensaje)
        {

            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del producto no puede estar vacio";

            }

            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripcion del producto no puede estar vacio";

            }

           else if (obj.oMarca.IdMarca == 0)
            {
                Mensaje = "Debes seleccionar Una marca";

            }
            else if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje = "Debes seleccionar una categoria";

            }else if (obj.Precio == 0)
            {
                Mensaje = "Debes ingreesar el precio del producto";

            }else if (obj.Stock == 0)
            {
                Mensaje = "Debes ingreesar el stock del producto";

            }

            if (string.IsNullOrEmpty(Mensaje))
            {


                return objCapaDato.Registrar(obj, out Mensaje);
            }
            else
            {
                return 0;
            }




        }


        public bool Editar(Producto obj, out string Mensaje)
        {
            Mensaje = string.Empty;

            if (string.IsNullOrEmpty(obj.Nombre) || string.IsNullOrWhiteSpace(obj.Nombre))
            {
                Mensaje = "El nombre del producto no puede estar vacio";

            }

            else if (string.IsNullOrEmpty(obj.Descripcion) || string.IsNullOrWhiteSpace(obj.Descripcion))
            {
                Mensaje = "La descripcion del producto no puede estar vacio";

            }

            else if (obj.oMarca.IdMarca == 0)
            {
                Mensaje = "Debes seleccionar Una marca";

            }
            else if (obj.oCategoria.IdCategoria == 0)
            {
                Mensaje = "Debes seleccionar una categoria";

            }
            else if (obj.Precio == 0)
            {
                Mensaje = "Debes ingreesar el precio del producto";

            }
            else if (obj.Stock == 0)
            {
                Mensaje = "Debes ingreesar el stock del producto";

            }

            if (string.IsNullOrEmpty(Mensaje))
            {
                return objCapaDato.Editar(obj, out Mensaje);
            }
            else
            {
                return false;
            }
        }

        public bool GuardarDatosImagen(Producto obj, out string Mensaje)
        {
            return objCapaDato.GuardarDatosImagen(obj, out Mensaje);
        }

        public bool Eliminar(int id, out string Mensaje)
        {
            return objCapaDato.Eliminar(id, out Mensaje);
        }
    }
}
