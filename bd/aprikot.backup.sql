PGDMP         4                x            postgres    12.1    12.1     ,           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            -           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            .           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            /           1262    13318    postgres    DATABASE     �   CREATE DATABASE postgres WITH TEMPLATE = template0 ENCODING = 'UTF8' LC_COLLATE = 'Russian_Russia.1251' LC_CTYPE = 'Russian_Russia.1251';
    DROP DATABASE postgres;
                postgres    false            0           0    0    DATABASE postgres    COMMENT     N   COMMENT ON DATABASE postgres IS 'default administrative connection database';
                   postgres    false    2863                        3079    16384 	   adminpack 	   EXTENSION     A   CREATE EXTENSION IF NOT EXISTS adminpack WITH SCHEMA pg_catalog;
    DROP EXTENSION adminpack;
                   false            1           0    0    EXTENSION adminpack    COMMENT     M   COMMENT ON EXTENSION adminpack IS 'administrative functions for PostgreSQL';
                        false    1            �            1259    16487    Albums    TABLE     i   CREATE TABLE public."Albums" (
    "Id" bigint NOT NULL,
    "Name" text,
    "Year" integer NOT NULL
);
    DROP TABLE public."Albums";
       public         heap    postgres    false            �            1259    16485    Albums_Id_seq    SEQUENCE     �   ALTER TABLE public."Albums" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Albums_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    205            �            1259    16497    Authors    TABLE     M   CREATE TABLE public."Authors" (
    "Id" bigint NOT NULL,
    "Name" text
);
    DROP TABLE public."Authors";
       public         heap    postgres    false            �            1259    16495    Authors_Id_seq    SEQUENCE     �   ALTER TABLE public."Authors" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Authors_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    207            �            1259    16507 
   References    TABLE     �   CREATE TABLE public."References" (
    "Id" bigint NOT NULL,
    "Author" bigint NOT NULL,
    "Song" bigint NOT NULL,
    "Album" bigint NOT NULL
);
     DROP TABLE public."References";
       public         heap    postgres    false            �            1259    16505    References_Id_seq    SEQUENCE     �   ALTER TABLE public."References" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."References_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    209            �            1259    16514    Songs    TABLE     K   CREATE TABLE public."Songs" (
    "Id" bigint NOT NULL,
    "Name" text
);
    DROP TABLE public."Songs";
       public         heap    postgres    false            �            1259    16512    Songs_Id_seq    SEQUENCE     �   ALTER TABLE public."Songs" ALTER COLUMN "Id" ADD GENERATED BY DEFAULT AS IDENTITY (
    SEQUENCE NAME public."Songs_Id_seq"
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1
);
            public          postgres    false    211            �            1259    16468    __EFMigrationsHistory    TABLE     �   CREATE TABLE public."__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL
);
 +   DROP TABLE public."__EFMigrationsHistory";
       public         heap    postgres    false            #          0    16487    Albums 
   TABLE DATA           8   COPY public."Albums" ("Id", "Name", "Year") FROM stdin;
    public          postgres    false    205   K       %          0    16497    Authors 
   TABLE DATA           1   COPY public."Authors" ("Id", "Name") FROM stdin;
    public          postgres    false    207   �       '          0    16507 
   References 
   TABLE DATA           G   COPY public."References" ("Id", "Author", "Song", "Album") FROM stdin;
    public          postgres    false    209   �       )          0    16514    Songs 
   TABLE DATA           /   COPY public."Songs" ("Id", "Name") FROM stdin;
    public          postgres    false    211   ,       !          0    16468    __EFMigrationsHistory 
   TABLE DATA           R   COPY public."__EFMigrationsHistory" ("MigrationId", "ProductVersion") FROM stdin;
    public          postgres    false    203   n       2           0    0    Albums_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Albums_Id_seq"', 2, true);
          public          postgres    false    204            3           0    0    Authors_Id_seq    SEQUENCE SET     >   SELECT pg_catalog.setval('public."Authors_Id_seq"', 4, true);
          public          postgres    false    206            4           0    0    References_Id_seq    SEQUENCE SET     B   SELECT pg_catalog.setval('public."References_Id_seq"', 35, true);
          public          postgres    false    208            5           0    0    Songs_Id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public."Songs_Id_seq"', 18, true);
          public          postgres    false    210            �
           2606    16494    Albums PK_Albums 
   CONSTRAINT     T   ALTER TABLE ONLY public."Albums"
    ADD CONSTRAINT "PK_Albums" PRIMARY KEY ("Id");
 >   ALTER TABLE ONLY public."Albums" DROP CONSTRAINT "PK_Albums";
       public            postgres    false    205            �
           2606    16504    Authors PK_Authors 
   CONSTRAINT     V   ALTER TABLE ONLY public."Authors"
    ADD CONSTRAINT "PK_Authors" PRIMARY KEY ("Id");
 @   ALTER TABLE ONLY public."Authors" DROP CONSTRAINT "PK_Authors";
       public            postgres    false    207            �
           2606    16511    References PK_References 
   CONSTRAINT     \   ALTER TABLE ONLY public."References"
    ADD CONSTRAINT "PK_References" PRIMARY KEY ("Id");
 F   ALTER TABLE ONLY public."References" DROP CONSTRAINT "PK_References";
       public            postgres    false    209            �
           2606    16521    Songs PK_Songs 
   CONSTRAINT     R   ALTER TABLE ONLY public."Songs"
    ADD CONSTRAINT "PK_Songs" PRIMARY KEY ("Id");
 <   ALTER TABLE ONLY public."Songs" DROP CONSTRAINT "PK_Songs";
       public            postgres    false    211            �
           2606    16472 .   __EFMigrationsHistory PK___EFMigrationsHistory 
   CONSTRAINT     {   ALTER TABLE ONLY public."__EFMigrationsHistory"
    ADD CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId");
 \   ALTER TABLE ONLY public."__EFMigrationsHistory" DROP CONSTRAINT "PK___EFMigrationsHistory";
       public            postgres    false    203            #   (   x�3��(�,.��K�4��4�2�L,N),�,�b���� �[	      %      x�3����	HM-�2����b���� S�       '   l   x�=�Q� C��a��x��CH�Ⱥ-8JWK�n��}�-M���n)N�N�Ȉl�pQCQDQ�Msq<(֦�(k�l���X�m��]Q�X�-������>�I      )   2   x�34�4�24�4�&��0�eh�YX��&��,9��MLL͸b���� 4      !   4   x�3202 "#CS#��������������Ē��<Nc=C=C�=... 3��     