DROP VIEW SIRCC.DNP2012;
/* Formatted on 2012/09/18 21:16 (Formatter Plus v4.8.8) */
CREATE OR REPLACE FORCE VIEW dnp2012 AS
   SELECT pro_con || nombre_proyecto den_proy_inv, ' ' act_proy_in, obj_con Objeto,
          numero, r.num_compromiso, r.cod_rubro || ':' || r.nom_gasto id_ppal,
          NVL (valregalias2012 (r.num_compromiso, r.cod_rubro),
               0
              ) val_regalias,
          NVL (valnoregalias2012 (r.num_compromiso, r.cod_rubro),
               0
              ) val_noregalias,
          val_con valor_total, fec_sus_con, c.fechainicio,
          0 etapa_precontractual, pla_eje_con plazo_ejecucion,
          0 oper_puestamarcha, 0 valor_anticipo,
          fechaant2012 (cod_con) fechapolanticipo,
          valpagado2012 (numero, SYSDATE) valorpagado,
          0 porcejecucionfinanciera, 0 porcavancefisico, c.contratista,
          c.idcontratista, c.nom_interventor, '' observaciones
     FROM vcontratos_sinc_p c INNER JOIN vrprub2012 r
          ON c.numero = r.cod_con AND r.vigencia = c.vig_con
          ;

