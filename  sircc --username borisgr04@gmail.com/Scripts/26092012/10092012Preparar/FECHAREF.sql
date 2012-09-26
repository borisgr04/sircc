/* Formatted on 2012/08/29 10:25 (Formatter Plus v4.8.8) */
CREATE OR REPLACE FUNCTION fecharef
   RETURN DATE
IS
BEGIN
   v.fecha_oper:='30/06/2012';
   RETURN v.fecha_oper;
END;