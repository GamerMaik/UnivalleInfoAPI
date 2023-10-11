using ENTIDADES.EPostgrado;
using HERRAMIENTAS;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SWDAUnivalleInfo.SWDAIPostgrado
{
    public class SWDAIPostgrado
    {
        #region Adicionar Postgrado
        public EResponse<int> Adicionar_Postgrado_EIPostgrado(EIPostgrado eIPostgrado)
        {
            EResponse<int> response = new EResponse<int>();
            try
            {
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    context.IPostgrado.Add(eIPostgrado);
                    context.SaveChanges();

                    response.Exitoso = true;
                    response.Mensaje = "Postgrado Adicionado Correctamente";
                    response.Datos = eIPostgrado.Id;
                }
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Error al Adicionar Postgrado";
                response.Excepcion = ex.Message;

            }
            return response;
        }
        #endregion

        #region Obtener Postgrado
        public EResponse<List<EIPostgrado>> Obtener_Postgrados()
        {
            EResponse<List<EIPostgrado>> response = new EResponse<List<EIPostgrado>>();

            try
            {
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    List<EIPostgrado> eIPostgrados = context.IPostgrado.ToList();
                    response.Exitoso = true;
                    response.Mensaje = "Postgrados Obtenidos Correctamente";
                    response.Datos = eIPostgrados;
                }
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "No se pudo Obtener los Postgrados";
                response.Excepcion = ex.Message;
            }

            return response;
        }
        #endregion

        #region Actualizar Postgrado
        public EResponse<bool> Actualizar_Postgrado_EIPostgrado(EIPostgrado eIPostgrado)
        {
            EResponse<bool> response = new EResponse<bool>();
            try
            {
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    var PostgradoExistente = context.IPostgrado.FirstOrDefault(p => p.Id == eIPostgrado.Id);
                    if (PostgradoExistente != null)
                    {
                        PostgradoExistente.TipoPostgrado = eIPostgrado.TipoPostgrado;
                        PostgradoExistente.Descripcion = eIPostgrado.Descripcion;
                        PostgradoExistente.RequisitosPostgrado = eIPostgrado.RequisitosPostgrado;

                        context.SaveChanges();

                        response.Exitoso = true;
                        response.Mensaje = "Postgrado Actualizado Exitosamente";
                        response.Datos = true;
                    }
                    else
                    {
                        response.Mensaje = "No se encuentra el Postgrado en la Base de datos";
                        response.Datos = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Exitoso = false;
                response.Mensaje = "Ocurrio un Error al Actualizar el Postgrado";
                response.Excepcion = ex.Message;
                response.Datos = false;
            }

            return response;
        }
        #endregion

        #region Eliminar Postgrado
        public EResponse<bool> Eliminar_Postgrado_PostgradoId(int postgradoId)
        {
            EResponse<bool> response = new EResponse<bool>();
            try
            {
                using (var context = new ApplicationDbContext(new DbContextOptions<ApplicationDbContext>()))
                {
                    var postgradoEliminar = context.IPostgrado.FirstOrDefault(p => p.Id == postgradoId);
                    if (postgradoEliminar != null)
                    {
                        context.IPostgrado.Remove(postgradoEliminar);
                        context.SaveChanges();

                        response.Exitoso = true;
                        response.Mensaje = "Postgrado Eliminado con Exito";
                        response.Datos = true;
                    }
                    else
                    {
                        response.Mensaje = "Postgrado no encontrado en la Base de Datos";
                        response.Datos = false;
                    }
                }
            }
            catch (Exception ex)
            {
                response.Exitoso = false;                
                response.Excepcion = ex.Message;
                response.Datos = false;
            }

            return response;
        }
        #endregion

    }
}
