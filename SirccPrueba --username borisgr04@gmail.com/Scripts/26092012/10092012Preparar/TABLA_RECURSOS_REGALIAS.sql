CREATE TABLE REC_REG (
 VIGENCIA VARCHAR2(4),
 TIP_REC VARCHAR2(4),
 RECURSOS VARCHAR2(2)
);

Insert into REC_REG
   (VIGENCIA, TIP_REC, RECURSOS)
 Values
   ('2012', 'REG', '18');
Insert into REC_REG
   (VIGENCIA, TIP_REC, RECURSOS)
 Values
   ('2012', 'REG', '21');
Insert into REC_REG
   (VIGENCIA, TIP_REC, RECURSOS)
 Values
   ('2012', 'REG', '19');
Insert into REC_REG
   (VIGENCIA, TIP_REC, RECURSOS)
 Values
   ('2012', 'REG', '22');
COMMIT;


