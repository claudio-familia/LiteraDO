<h1 align="center">
  LiteraDO
</h1>
<h2>Webservice - API</h2>
<p>
  <b>The LiteraDO API</b> Es un servicio web que pretende ser la aplicación que se encargue de la gestión de la logica de la aplicación mobil asi como ser eje central para la seguridad de los datos de los usuarios.    
</p>
<p>
  El software está siendo desarrollado en .NET Core 6, utilizando una base de datos con MySQL con una arquitectura de cebolla.
</p>

<h3>Arquitecture (Arquitectura)</h3>
<ul>
  <h4>Onion arquitecture</h4>
  <p>
  La arquitectura de cebolla o onion architecture es un patrón arquitectónico que permite sistemas empresariales evolutivos y mantenibles. Está diseñado para ser usado a nivel de capas, las cuales mantienen la aplicación desacoplada, testeable y mantenible garantizando la simpleza sin perder escalabilidad
  </p>
  <h4>Test driven development</h4>  
  <p>
  Desarrollo guiado por pruebas de software, o Test-driven development (TDD) es una práctica de ingeniería de software que involucra otras dos prácticas: Escribir las pruebas primero (Test First Development) y Refactorización (Refactoring). Para escribir las pruebas generalmente se utilizan las pruebas unitarias (unit test en inglés)
  </p>
</ul>

<h3>Environtment (Ambientes)</h3>
<ul>
  <h4>Azure</h4>
  <p>
    El ambiente de publicación que estamos utilizando es hosteado en heroku. Heroku es una plataforma como servicio (PaaS) de computación en la Nube que soporta distintos lenguajes de programación. Nuestra aplicacion es hospedada allí gracias a que la tenemos en un contenedor de docker.
  </p>
  <h4>Continous Delivery</h4>
  <p>
   El proyecto es publicado por medio a lo que se conoce como continous delivery o deployment, lo cual consiste en un enfoque de la ingeniería del software en que los equipos de desarrollo producen software en ciclos cortos, asegurando que el software puede ser liberado en cualquier momento, de forma confiable en cualquier momento
  </p>
</ul>

<h3>Security (Seguridad)</h3>
<ul>
  <h4>Json web tokens</h4> 
  <p>
    La aplicación cuenta con una seguridad utilizando lo que es Json web tokens que es un estándar abierto basado en JSON propuesto por IETF (RFC 7519) para la creación de tokens de acceso que permiten la propagación de identidad y privilegios o claims en inglés. Por ejemplo, un servidor podría generar un token indicando que el usuario tiene privilegios de administrador y proporcionarlo a un cliente.
  <p>
</ul>

<h3>Data persistency (Persistencia de datos)</h3>
<ul>
  <h4>MySQL</h4> 
  <p>
    La persistencia de datos en la aplicación la manejamos utiliznado el gestor de bases de datos MySQL el cual es un sistema de gestión de bases de datos relacional desarrollado bajo licencia dual; una de las más populares en general junto a Oracle y Microsoft SQL Server, todo para entornos de desarrollo web. El servicio lo utilizamos a traves de Jaws que es ofrecido por heroku.
  </p>
  <p>
    Para general modelos debes usar el siguiente comando luego de hacer los cambios en el dbcontext:
    <pre>
     cd .\LiteraDO.DataAccess
     dotnet ef --startup-project ../LiteraDO/ migrations add MigrationName
    </pre>
  </p>
  
</ul>

<h2>Web - SPA</h2>

<h3>Angular</h3>
  <b>The LiteraDO SPA</b> Es un Single Page Application que se encarga de la gestion de los usuarios y documentos.
</p>
<p>
  El software está siendo desarrollado con Angular, utilizando una base de datos con MySQL con una arquitectura de cebolla.
</p>


<h2>Web - Admin</h2>