CREATE OR REPLACE VIEW VALERTCONTRATOS
(NUMERO, FEC_SUS_CON, FEC_APR_POL, FECHAINICIO, DIASEJECUTADOS, 
 PLAZO_TOTAL, XEJECUTAR, FECHAFINAL, FECHALIQ, PLA_EJE_CON, 
 ADICION, SUSPENCION, TOTAL, FECHAFINALPROB, EST_CON, 
 DEPENDENCIA, DEPENDENCIAP, ESTADO, OBJ_CON, VIG_CON)
AS 
SELECT numero, fec_sus_con, fec_apr_pol, fechainicio,
       tiempoejecutado (numero) diasejecutados, plazo_total,
       pla_eje_con - tiempoejecutado (numero) xejecutar, fechafinal, fechaliq,
       Pla_eje_Con,Plazo_Adicion_dias(Numero) Adicion, suspencion (numero) suspencion,
       Pla_eje_Con+Plazo_Adicion_dias(Numero) + suspencion (numero) total,
       nvl(fechainicio,nvl(fec_apr_pol, fec_sus_con))+Pla_eje_Con+Plazo_Adicion_dias(Numero) + suspencion (numero) FechaFinalProb,
       est_con,Dependencia,DependenciaP,
       estado, obj_con, vig_con
  FROM vcontratos_sinc_p
 --WHERE numero LIKE '2011020441'
/

