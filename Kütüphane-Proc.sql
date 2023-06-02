--******Uye******
create proc UListele
as begin
select * from Uye
end 

create proc UEkle
@AdSoyad varchar(50),
@Mail varchar(50),
@Adres varchar(50),
@Tel varchar(50)
as begin
insert into Uye (AdSoyad, Mail, Adres,Tel)
	values (@AdSoyad, @Mail, @Adres,@Tel)
end

create proc UGuncelle
@UyeNo int,
@AdSoyad varchar(50),
@Mail varchar(50),
@Adres varchar(50),
@Tel varchar(50)
as begin
update Uye set
	 AdSoyad=@AdSoyad, Mail=@Mail, Adres=@Adres,Tel=@Tel where UyeNo=@UyeNo
end

create proc USil
@UyeNo int
as begin 
delete from Uye where UyeNo=@UyeNo
end

create proc UAra
@AdSoyad varchar(50)
as begin
select * from Uye where AdSoyad=@AdSoyad
end

--******Kitap******
create proc KListele
as begin 
select * from Kitap
end

create proc KEkle
@KitapAd varchar(50),
@Yazar varchar(50),
@Turu varchar(50),
@RafKodu varchar(50),
@BaskiYili varchar(50),
@Sayfa int,
@Yayinevi varchar(50),
@Dil varchar(50)
as begin 
insert into Kitap (KitapAd, Yazar, Turu, RafKodu,BaskiYili,Sayfa,Yayinevi,Dil)
	values (@KitapAd, @Yazar, @Turu, @RafKodu,@BaskiYili,@Sayfa,@Yayinevi,@Dil)
end

create proc KGuncelle
@KitapNo int,
@KitapAd varchar(50),
@Yazar varchar(50),
@Turu varchar(50),
@RafKodu varchar(50),
@BaskiYili varchar(50),
@Sayfa int,
@Yayinevi varchar(50),
@Dil varchar(50)
as begin 
update Kitap set 
	KitapAd=@KitapAd, Yazar=@Yazar, Turu=@Turu, RafKodu=@RafKodu,BaskiYili=@BaskiYili,Sayfa=@Sayfa,Yayinevi=@Yayinevi,Dil=@Dil where KitapNo=@KitapNo
end

create proc KSil
@KitapNo int
as begin 
delete from Kitap where KitapNo=@KitapNo
end

create proc KAra
@KitapAd varchar(50)
as begin
select * from Kitap where KitapAd=@KitapAd
end

--******VerilenKitap******
create proc VListele
as begin 
select * from VerilenKitap
end

alter proc VEkle
@UNo int,
@KNo int,
@KisiAd varchar(50),
@KitapAd varchar(50),
@RafKodu varchar(50),
@VerilisT datetime,
@ÝadeT datetime,
@KitapDurumu varchar(50)
as begin 
insert into VerilenKitap (UNo, KNo, KisiAd, KitapAd, RafKodu, VerilisT, ÝadeT,KitapDurumu)
	values (@UNo, @KNo, @KisiAd, @KitapAd, @RafKodu, @VerilisT, @ÝadeT,@KitapDurumu)
end

create proc VGuncelle
@ÝslemNo int,
@UNo int,
@KNo int,
@KisiAd varchar(50),
@KitapAd varchar(50),
@RafKodu varchar(50),
@VerilisT datetime,
@ÝadeT datetime,
@KitapDurumu varchar(50)
as begin 
update VerilenKitap set 
	UNo=@UNo, KNo=@KNo, KisiAd=@KisiAd, KitapAd=@KitapAd, RafKodu=@RafKodu, VerilisT=@VerilisT, ÝadeT=@ÝadeT, KitapDurumu=@KitapDurumu where ÝslemNo=@ÝslemNo
end

alter proc VSil
@ÝslemNo int
as begin 
delete from VerilenKitap where ÝslemNo=@ÝslemNo
end

create proc VAra
@KisiAd varchar(50)
as begin
select * from VerilenKitap where KisiAd=@KisiAd
end

--******Kullanýcý******

create proc KullaniciEkle
@KullaniciAd varchar(50),
@Sifre varchar(50),
@AdSoyad varchar(50)
as begin
insert into Kullanici (KullaniciAd,Sifre,AdSoyad)
	values (@KullaniciAd,@Sifre,@AdSoyad)
end

create procedure Giris 
@kad varchar(50),
@sifre varchar(50)
as begin 
select * from Kullanici where 
	KullaniciAd = @kad and Sifre = @sifre
end


--***********Sorgu**********
create proc S1
as begin
select * from Kitap 
	where Dil = 'Ýngilizce' 
	order by KitapAd asc
end

create proc S2
as begin 
select AdSoyad,Mail, Tel, KitapAd,RafKodu,VerilisT,ÝadeT,KitapDurumu from Uye u join VerilenKitap vk on u.UyeNo = vk.UNo 
end

alter proc S3
as begin 
select Turu, count(KitapNo) as 'Kitap Sayýsý' from Kitap group by Turu
end 