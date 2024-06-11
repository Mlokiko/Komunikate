Prosty Komunikator tekstowy

<strong> PROJEKT STUDENCKI, JEŻELI SZUKASZ PRAWDZIWEGO KOMUNIKATORA, OSZCZĘDZ SOBIE NERWÓW </strong>

Do poprawnego działania wymagane jest:
- posiadanie zainstalowanego (i ofc działąjącego) postgresa, standardowo aplikacja korzysta z standardowej bazy danych "postgres" na porcie 5432
- zaimportowanie projekt.sql (znajduje się w folderze resources) który:
  - zaimportuje wymagane tabele
  - zaimportuje wymaganych użytkowników (testconnection, usercreator, userdeleater) wraz z uprawnieniami
  - zaimportuje triggery oraz funkcje składowane

Plik projekt.sql zawiera również testową zawartość bazy danych (przykładowych użytkowników, ich statusy znajomości oraz wiadomości)

<br><br><br><br><br>


Copyright (c) <2024>, <Mlokiko>
All rights reserved.

This source code is licensed under the BSD-style license found below:


MIT License

Copyright (c) 2024 Mlokiko

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
