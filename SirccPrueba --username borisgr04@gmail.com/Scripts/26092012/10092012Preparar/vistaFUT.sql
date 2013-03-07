-- FALTA EN .NET ,MANDAR LA FECHAD E REFERENCIA
/* Formatted on 2012/08/29 10:21 (Formatter Plus v4.8.8) */
CREATE OR REPLACE VIEW vFUT2012_01 AS
SELECT   cod_rub, nro_rp, tipo, nom_stip, numero, to_char(fec_sus_con,'dd/mm/yyyy') fec_sus_con, 'Reserva?' r,
         pro_con AS programa, pro_con proyecto, obj_con,
         val_compromiso valorxrp, valor_total_prop valorxcontrato,
         valregalias2012 (nro_rp, cod_rub) val_regalias,
         valpagado2012 (numero, fecharef) val_pagado,
         valpagoregaliasxrubro2012 (nro_rp,
                                    cod_rub,
                                    fecharef
                                   ) val_regaliasxrubros,
         valpagadoregalias2012 (numero, fecharef) val_pagado_regalias,
         CASE tipoidentificacion
            WHEN 'CC'
               THEN 'Cedula'
            WHEN 'NI'
               THEN 'Nit'
            WHEN 'CE'
               THEN 'Cedula Extranjeria'
         END tipoidentifiacion,
         ide_con, TRIM (contratista) contratista,
         to_char(fechainicio,'dd/mm/yyyy') fec_inicio,
         case when pla_eje_con<30 then 0 else Round(pla_eje_con/30,0) end  
          plazo_mes, 0 suspension, 
         pla_adicion_dias,
         to_char((fechainicio + plazo_total),'dd/mm/yyyy') AS fechafinalizacion,
         TRIM (rep_legal) rep_legal, nom_interventor,
         (SELECT Nvl(SUM (nvisitas),0) nvisitas FROM estcontratos WHERE cod_con = numero) visitasrealizadas
    FROM vcontratos_sinc_p_r2
    --WHERE  
--   WHERE numero LIKE '2012%'
--     AND fec_sus_con BETWEEN '01/01/2012' AND '30/06/2012'
--ORDER BY numero

