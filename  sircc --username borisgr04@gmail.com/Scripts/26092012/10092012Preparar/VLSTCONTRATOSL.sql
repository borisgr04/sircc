CREATE OR REPLACE FORCE VIEW vlstcontratosL 
AS
   SELECT numero, 
          TO_CHAR (fec_sus_con,
                   'dd "de" FMMONTH "del" yyyy'
                  ) "FECHA DE SUSCRIPCI�N",
          TRIM (TO_CHAR (NVL(val_con,0), '999,999,999.99')) "VALOR",
          plazo1_eje_con|| DECODE(TIPO_PLAZO,'D',' DIAS','M',' MESES','A',' A�OS') "PLAZO DE EJECUCI�N",
          TRIM (TO_CHAR (NVL(val_adi,0), '999,999,999.99')) "VALOR ADICIONADO",
          TRIM (TO_CHAR (NVL(valor_total_doc,0), '999,999,999.99')) "VALOR TOTAL",
          pla_adi "PLAZO ADICIONADO", plazo_texto "TOTAL PLAZO DE EJECUCI�N",
          TO_CHAR (fechainicio,
                   'dd "de" FMMONTH "del" yyyy'
                  ) "FECHA DE INICIO",
          TO_CHAR (fechafinal,
                   'dd "de" FMMONTH "del" yyyy'
                  ) "FECHA TERMINACI�N",
          TO_CHAR (fechaliq,
                   'dd "de" FMMONTH "del" yyyy'
                  ) "FECHA DE LIQUIDACI�N",
          ide_con
     FROM vcontratos_sinc_p;

 