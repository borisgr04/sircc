/* Formatted on 2012/09/18 23:13 (Formatter Plus v4.8.8) */
CREATE OR REPLACE FUNCTION obtenervalconxcdp2012 (
   icod_con   varchar,
   inro_cdp   VARCHAR
)
   RETURN NUMBER
IS
   val_com   NUMBER;
BEGIN
   SELECT SUM (val_compromiso)
     INTO val_com
     FROM pct2012_dcompromiso rpc
     inner join pct2012_mcompromiso mrp
     On mrp.Vigencia=rpc.Vigencia And rpc.Num_Compromiso=mrp.Num_Compromiso
    WHERE nro_documento = icod_con
      AND mrp.num_certificado = inro_cdp
      AND rpc.vigencia = 2012;

   RETURN val_com;
END;