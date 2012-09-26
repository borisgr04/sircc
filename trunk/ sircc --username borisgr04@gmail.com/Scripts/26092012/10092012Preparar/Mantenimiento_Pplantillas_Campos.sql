Delete(
select * from pplantillas_campos where vista='VCONTRATOS_SINC_P' and (Nom_Pla = 'ESTADO' And Nom_Cam='EST_CON')
); 
Delete(
Select * from pplantillas_campos where vista='VCONTRATOS_SINC_P' and (Nom_Pla IN('DEP_NEC','TIP_CON','STIP_CON','COD_SECTOR','OTR_CNS','DOC_CON
','COD_TPROCESO','EST_CONV','COD_DEP_DEL','PER_APO','TIP_RADICACION','TIPOTERCERO','IDE_INTERVENTOR','NRO_CON','NUM_PROC'))
); 
Commit;


