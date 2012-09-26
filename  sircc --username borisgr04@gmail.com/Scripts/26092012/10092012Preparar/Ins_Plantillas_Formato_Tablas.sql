delete PPLANTILLAS_FORMATO_TABLAS;
select * from PPLANTILLAS_FORMATO_TABLAS ;
--SET DEFINE OFF;
Insert into PPLANTILLAS_FORMATO_TABLAS
   (IDE_PLA, NTABLA, NOM_CAM, TIP_DAT, ANCHO)
 Values
   (32, 'VLSTCONTRATOS', 'COLUMN1', 'C', 120);
Insert into PPLANTILLAS_FORMATO_TABLAS
   (IDE_PLA, NTABLA, NOM_CAM, TIP_DAT, ANCHO)
 Values
   (32, 'VLSTCONTRATOS', 'COLUMN2', 'C', 410);
COMMIT;

 
DELETE  pplantillas_campos where vista like 'VCERT%';
 
--SET DEFINE OFF;
Insert into PPLANTILLAS_CAMPOS
   (NOM_CAM, NOM_PLA, TIP_DAT, EST_CAM, GTABLA, ENCABEZADO_PIE, MOSTRAR_TITULOS, MOSTRAR_BORDE, VISTA, MARCADOR, IDE_PLA, COL_FINAL, TAGRUPADA)
 Values
   ('NRO_CERT', 'NRO_CER', 'C', 'AC', 'N', 'NO', 'NO', 'NO', 'VCERTIFICACIONES', 'NO', 32, 0, 'N');
Insert into PPLANTILLAS_CAMPOS
   (NOM_CAM, NOM_PLA, TIP_DAT, EST_CAM, GTABLA, ENCABEZADO_PIE, MOSTRAR_TITULOS, MOSTRAR_BORDE, VISTA, MARCADOR, IDE_PLA, COL_FINAL, TAGRUPADA)
 Values
   ('FEC_CERT', 'FECHA_CERTIFICADO', 'DL', 'AC', 'N', 'NO', 'NO', 'NO', 'VCERTIFICACIONES', 'NO', 32, 0, 'N');
Insert into PPLANTILLAS_CAMPOS
   (NOM_CAM, NOM_PLA, TIP_DAT, EST_CAM, GTABLA, ENCABEZADO_PIE, MOSTRAR_TITULOS, MOSTRAR_BORDE, VISTA, MARCADOR, IDE_PLA, COL_FINAL, TAGRUPADA)
 Values
   ('CONTRATISTA', 'NOM_CONTRATISTA', 'C', 'AC', 'N', 'NO', 'NO', 'NO', 'VCERTIFICACIONES', 'NO', 32, 0, 'N');
Insert into PPLANTILLAS_CAMPOS
   (NOM_CAM, NOM_PLA, TIP_DAT, EST_CAM, GTABLA, ENCABEZADO_PIE, MOSTRAR_TITULOS, MOSTRAR_BORDE, VISTA, MARCADOR, IDE_PLA, COL_FINAL, TAGRUPADA)
 Values
   ('NOM_TIP_IDE', 'TIP_IDE_CONTRATISTA', 'C', 'AC', 'N', 'NO', 'NO', 'NO', 'VCERTIFICACIONES', 'NO', 32, 0, 'N');
Insert into PPLANTILLAS_CAMPOS
   (NOM_CAM, NOM_PLA, TIP_DAT, EST_CAM, GTABLA, ENCABEZADO_PIE, MOSTRAR_TITULOS, MOSTRAR_BORDE, VISTA, MARCADOR, IDE_PLA, COL_FINAL, TAGRUPADA)
 Values
   ('EXP_IDE', 'LUG_EXPEDICION_IDE', 'C', 'AC', 'N', 'NO', 'NO', 'NO', 'VCERTIFICACIONES', 'NO', 32, 0, 'N');
Insert into PPLANTILLAS_CAMPOS
   (NOM_CAM, NOM_PLA, TIP_DAT, EST_CAM, GTABLA, NTABLA, ENCABEZADO_PIE, MOSTRAR_TITULOS, MOSTRAR_BORDE, VISTA, MARCADOR, IDE_PLA, COL_FINAL, TAGRUPADA)
 Values
   ('LISTA_CONTRATOS', 'LISTA_CONTRATOS', 'TV', 'AC', 'S', 'VLSTCONTRATOS', 'NO', 'NO', 'SI', 'VCERTIFICACIONES', 'NO', 32, 0, 'N');
Insert into PPLANTILLAS_CAMPOS
   (NOM_CAM, NOM_PLA, TIP_DAT, EST_CAM, GTABLA, ENCABEZADO_PIE, MOSTRAR_TITULOS, MOSTRAR_BORDE, VISTA, MARCADOR, IDE_PLA, COL_FINAL, TAGRUPADA)
 Values
   ('IDE_CON', 'IDE_CONTRATISTA', 'n', 'AC', 'N', 'NO', 'NO', 'NO', 'VCERTIFICACIONES', 'NO', 32, 0, 'N');
Insert into PPLANTILLAS_CAMPOS
   (NOM_CAM, NOM_PLA, TIP_DAT, EST_CAM, GTABLA, ENCABEZADO_PIE, MOSTRAR_TITULOS, MOSTRAR_BORDE, VISTA, MARCADOR, IDE_PLA, COL_FINAL, TAGRUPADA)
 Values
   ('VIG_CERT', 'VIGENCIA_CERT', 'C', 'AC', 'N', 'NO', 'NO', 'NO', 'VCERTIFICACIONES', 'NO', 32, 0, 'N');
Insert into PPLANTILLAS_CAMPOS
   (NOM_CAM, NOM_PLA, TIP_DAT, EST_CAM, GTABLA, ENCABEZADO_PIE, MOSTRAR_TITULOS, MOSTRAR_BORDE, VISTA, MARCADOR, IDE_PLA, COL_FINAL, TAGRUPADA)
 Values
   ('COD_SERIE', 'COD_VERIFICACION', 'C', 'AC', 'N', 'NO', 'NO', 'NO', 'VCERTIFICACIONES', 'NO', 32, 0, 'N');
COMMIT;
