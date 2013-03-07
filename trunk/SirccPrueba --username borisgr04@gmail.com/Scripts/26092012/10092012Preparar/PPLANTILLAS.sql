insert into TIPPLANTILLAS VALUES('03','CERTIFICACION CONTRATO');
COMMIT;
CREATE OR REPLACE FORCE VIEW vpplantillasdb
AS
   SELECT ide_pla, NOM_TIPPLA TIPO_PLANTILLA,Decode(tip_pla,'01',nom_stip,'03','Certificaciones') Clase, nom_pla, ext, est_pla, p.cod_stip, usap, usbd,
          fec_reg, usbd_mod, usap_mod, fec_mod, clave,  editable,tip_pla
     FROM pplantillas p LEFT JOIN subtipos stp ON p.cod_stip = stp.cod_stip
     INNER JOIN TIPPLANTILLAS TP ON ID_TIPPLA=TIP_PLA
--WHERE EST_PLA='AC';



