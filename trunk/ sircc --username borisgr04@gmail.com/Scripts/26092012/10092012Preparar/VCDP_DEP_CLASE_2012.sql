CREATE OR REPLACE VIEW VCDP_DEP_CLASE_2012 AS 
SELECT   nro_cdp, dependencia necesidad, clase, COUNT (distinct numero) cantidad,
         SUM (val_com) VALORXCDP
from(
select distinct nro_cdp,numero,dependencia,tipo || '-' || nom_stip clase, obtenervalconxcdp2012(numero,obtenercdp2012(nro_rp)) val_com from (
        select * from (
          SELECT obtenercdp2012(nro_rp) nro_cdp,
                 c.*
            FROM vcontratos_sinc_p_r2 c
                     WHERE vig_con = 2012)   
    ) 
Order by numero
)
group by nro_cdp,dependencia,clase
ORDER BY nro_cdp, dependencia,clase;
