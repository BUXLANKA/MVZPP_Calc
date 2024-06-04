create table KNPR_GG_CALC_RES
(
	N int identity(1,1) primary key not null,
	mGG float not null,
	pGG float not null,
	CnkprGG float not null,
	R_result_for_GG float not null, 
	Z_result_for_GG float not null,
);

create table KNPR_LVZH_CALC_RES
(
	N int identity(1,1) primary key not null,
	mPP float not null,
	pPP float not null,
	CnkprPP float not null,
	R_result_for_PP float not null, 
	Z_result_for_PP float not null,
);