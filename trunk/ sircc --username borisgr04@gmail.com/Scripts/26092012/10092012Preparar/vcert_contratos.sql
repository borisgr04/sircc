/* Formatted on 2012/09/10 22:06 (Formatter Plus v4.8.8) */
CREATE OR REPLACE VIEW vcert_contratos
AS
   SELECT c.*,
             TO_CHAR (fec_cert, 'YYYYMMDDWWHH24MMSS')
          || LPAD (nro_cert, 5, '0') cod_serie
     FROM cert_contratos c
     
     
     
     
     
     
