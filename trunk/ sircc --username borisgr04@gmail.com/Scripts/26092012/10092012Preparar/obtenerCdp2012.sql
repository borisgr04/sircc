/* Formatted on 2012/09/18 23:01 (Formatter Plus v4.8.8) */
CREATE OR REPLACE FUNCTION obtenercdp2012 (inro_rp NUMBER)
   RETURN NUMBER
IS
   nro_cdp   NUMBER;
BEGIN
   SELECT num_certificado
     INTO nro_cdp
     FROM pct2012_mcompromiso rpc
    WHERE num_compromiso = inro_rp AND vigencia = '2012';

   RETURN nro_cdp;
END;