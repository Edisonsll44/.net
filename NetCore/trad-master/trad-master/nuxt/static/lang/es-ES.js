export default () => {
  return new Promise(function(resolve) {
    resolve({
      menu: {
        "index": "Inicio",
        "login": "Inicio de Sesión",
        "contacto": "Contacto",
        "usuarios": "Administración de Usuarios",
        "perfil": "Perfil de Usuario",
        "usuario": "Dashboard",
        "configuracion": "Configuración de Sistema",
        "pagos": "Pagos",
        "pagos_val": "Validación de Pagos",
        "register": "Registro",
        "validate": "Validación de Cuenta",
        "forgot": "Recuperar Cuenta",
        "change": "Nueva Contraseña",
        "logout": "Cerrar Sesión",
      },
      colors: {
        "EN PROCESO":"blue",
        "APROBADO":"green",
        "RECHAZADO":"red",
      },
      push: {
        "you_pay": "Tu pago de ",
        "pay_detail": " fue ",
        "new_pay": " ha creado un nuevo pago de ",
      },
      database: {
        "componente":"Funcionalidad",
        "rolid":"Rol",
        "nombres":"Nombre",
        "apellidos":"Apellido",
        "rol":"Rol",
        "idRol":"Rol",
        "rolId":"Rol",
        "valor":"Valor",
        "fechaPago":"Fecha",
        "formaPago":"Forma de pago",
        "estado":"Estado",
        "id":"Identificador",
        "nombre":"Nombre",
        "referencia":"Referencia de pago",
        "tipoCuenta":"Tipo de cuenta",
        "codigo":"Código",
        "cuentaDeposito":"Nº de cuenta",
        "correo":"Correo Electrónico",
        "cuenta":"Nº de cuenta",
        "banco":"Banco",
        "TipoCuenta":"Tipo de cuenta",
        "tipoIdentificacion":"Tipo de identificación",
        "identificacion":"Nº de identificación",
        "email":"Correo electrónico",
      },
      fulluse: {
        "no_notifications": "No tienes notificaciones",
        "search": "Buscar",
        "user": "Usuario",
        "actions": "Acciones",
        "add_suc": "agregado Exitosamente",
        "edit_suc": "modificado Exitosamente",
        "del_suc": "eliminado Exitosamente",
        "del_confir": "¿Estas seguro?",
        "new": "Nuevo",
        "edit": "Editar",
        "del": "Eliminar",
        "bank": "Banco",
        "banks": "Bancos",
        "type-pays": "Formas de pago",
        "type-pay": "Forma de pago",
        "accounts": "Cuentas bancarias",
        "account": "Cuenta bancaria",
        "type-accounts": "Tipo de cuentas",
        "menu": "Menú",
        "yes": "Si",
        "no": "No",
        "type_bank": "Tipo de cuenta",
        "reference": "Referencia",
        "my_profile":"Mi Perfil",
        "verification_progres":"Verificación en Progreso",
        "email_confirmation":"Confirmación de email",
        "phone_confirmation":"Confirmación de teléfono",
        "ide_confirmation":"Verificación de identidad",
        "of": "de",
        "all": "Todos",
        "next": "siguiente",
        "prev": "anterior",
        "page": "Página",
        "table_page": "Registros por página",
        "order_by": "Ordenar por",
        "search_pp": "Buscar por nombre o número de cédula",
        "status": "Estado",
        "detail": "Ver Detalle",
        "close": "Cerrar",
        "detail_pay": "Detalle de Pago",
        "status_pay": "Estado de Pago",
        "status_pay_datail": "¿Estas seguro de cambiar el estado de pago?",
        "acept": "Aceptar",
        "reject": "Cancelar",
        "retry": "Reintentar",
        "value": "Valor",
        "cuenta": "Nº de cuenta",
        "need_auth": "Debes iniciar sesión primero",
        "need_admin": "No tienes autorizacion para ingresar",
        "no_pays": "No tienes pagos registrados",
        "no_data": "No hay registros",
        "process": "Procesando",
        "filter_per": "Filtro por",
      },
      common: {
        "dir": "Dirección",
        "saldo": "Saldo",
        "ref": "Referidos",
        "error_componet": "No existe un formulario definido para esta funcionalidad, por favor use una que este activa.",
        "update_profile": "Tu información de perfil se ha guardado exitosamente",
        "pay_list": "Lista de pagos realizados",
        "logout_title": "Cerrar Sesión",
        "logout_force": "Sesión Caducada",
        "logout_question": "¿Quieres cerrar tu sesión Actual?",
        "send_email": "Enviar correo",
        "send": "Enviar",
        "date": "Fecha",
        "file": "Archivo",
        "file_val": "Elije una imagen",
        "count": "Cantidad",
        "hour": "Hora",
        "error_with_status": "Ha ocurrido un error.",
        "404": "Esta página no esta disponible.",
        "404_subtitle": "Puedes regresar al comienzo",
        "back": "regresar al inicio",
        "error_without_status": "Ha ocurrido un error en el servidor",
        "contact_title": "Conversemos",
        "contact_title2": "Escríbenos",
        "contact_subtitle": "¿Tienes alguna pregunta? Contáctanos y será un gusto conversar contigo",
        "form_name": "¿Cuál es tu nombre?",
        "form_email": "¿Cuál es tu correo electrónico?",
        "form_phone": "¿Cuál es tu número de celular?",
        "form_company": "¿Cuál es tu empresa?",
        "form_message": "Escribe un mensaje aquí",
        "form_terms": "Ya he leído",
        "form_privacy": "Términos y Condiciones *",
        "form_send": "Enviar Mensaje",
        "login": "ingresar",
        "forgot_pasword": "¿Olvidaste tu contraseña?",
        "login_create": "Crear cuenta nueva",
        "login_or": "Inicia sesión con tu correo electrónico",
        "login_email": "Correo electrónico",
        "login_password": "Contraseña",
        "login_remember": "Recuérdame",
        "login_forgot": "Olvidaste tu contraseña",
        "continue": "Continuar",
        "save": "Guardar",
        "login_title": "Bienvenido",
        "login_subtitle": "Ingresa para continuar",
        "register": "Registro",
        "register_already": "¿Ya tienes una cuenta?",
        "register_or": "Registro con correo electrónico",
        "reset_message": "Ingresa una nueva contraseña",
        "enter_email": "Ingresa tu correo electrónico",
        "register_name": "Nombres",
        "register_email": "Correo electrónico",
        "register_password": "Contraseña",
        "register_confirm": "Confirmación de contraseña",
        "register_title": "Un gusto conocerte :)",
        "validate_continua": "Valida tu cuenta para continuar",
        "register_subtitle": "Solo registrate para unirte",
        "tipo_doc": "Tipo de identificación",
        "no_doc": "Nº de identificación",
        "name": "Nombres",
        "last_name": "Apellidos",
        "email": "Correo electrónico",
        "country": "País/Región",
        "phone": "Nº telefónico",
        "validate": "Validar cuenta",
        "reset_pasword": "Cambia tu contraseña",
        "login_validate": "Inicia sesión",
        "ref_code": "Código de referencia",
        "after_register": "Un mail ha sido enviado a tu correo electrónico, para verificar tu cuenta.",
        "after_reset": "Un mail ha sido enviado a tu cuenta con un link de verificación.",
        "accept": "Aceptar",
        "error_login": "El correo electrónico o la contraseña son incorrectos.\nIntenta de nuevo.",
        "en": "Inglés",
        "es": "Español",
        "message_dep": "Por confidencialidad recibiras un mail con los números de cuentas a los cuales podras realizar los\ndepositos. Una vez realizado el depósito comparte el comprobante para poder registrarlo.",
        "after_pay": "El depósito realizado será acreditado a su perfil.",
        "up_pay": "Subir comprobante",
        "dep_title": "Nuevo registro de depósito",
        "validate_true": "Se ha validado correctamente tu cuenta, por favor inicia sesión.",
        "to_top": "Arriba",
        "resend": "Reenviar",
        "otp_title": "Validación de dos pasos",
        "code": "Código",
        "code_feed": "Es un código de 5 caracteres",
        "form_contac": "Formulario de Contacto",
        "form_post_send":"Gracias por preferirnos!"
      },
      saasLanding: {
        "header_academy": "Trading Academy",
        "header_academy_sub": "Ser un trader exitoso es posible, cuando existe una formación personal y académica adecuada que respalde un plan de acción exitoso, con bases metodológicas y estrategias que irás aprendiendo a lo largo del camino para mejorar tus habilidades en el mercado.",
        "header_expertos": "Expertos en la formación de profesionales de Trading",
        "header_aprende": "Aprende mientras inviertes",
        "header_aprende_sub": "Amplia tus conocimientos en mercados financieros, a través de metodologías y estrategias de inversión, genera dinero de forma fácil y asequible.",
        "header_login": "iniciar sesión",
        "header_register": "registrar",
        "header_language": "Idioma",
        "header_theme": "Modo",
        "header_dark": "Oscuro",
        "header_light": "Claro",
        "header_feature": "misión",
        "header_feature_subtitle": "Formar de manera integral, académica y profesional a cada uno de nuestros alumnos, brindándoles soporte y acompañamiento en las distintas etapas de su desarrollo. Desde el respeto en sus creeencias, hasta la aplicación y comprobación de sus conocimientos aplicados. A través de una educación guiada basada en buenos hábitos de estudio y formación académica de calidad que respondan a las demandas del mercado.",
        "header_vision": "visión",
        "header_vision_subtitle": "Ser líder en escuelas de formación y aprendizaje de trading de manera global, siendo un referente que garantice la formación personal y académica a través de estrategias y metodologías innovadoras que permitan a nuestros estudiantes estar alineados a los progresos y desafíos actuales del mercado financiero.",
        "header_testimonials": "expertos",
        "header_pricing": "planes",
        "header_faq": "aprende",
        "header_contact": "contacto",
        "banner_title": "Parte de conceptos",
        "banner_titlestrong": "básicos y genera rentabilidad",
        "banner_subtitle": "Nuestra plataforma está diseñada para impulsar tu crecimiento profesional y conocer más acerca del mercado financiero, liderado por expertos en inversión",
        "banner_watchvideo": "Ver Video",
        "getstarted": "empezar",
        "counter_month": "Mes",
        "counter_free": "Prueba Gratis",
        "counter_users": "Usuarios Activos",
        "counter_providers": "Proveedores",
        "see_detail": "Ver Detalles",
        "testi_title": "Quiénes son nuestros clientes",
        "testi_titlestrong": "Testimonios",
        "pricing_title": "Nuestros Planes",
        "pricing_subtitle": "Accede a herramientas que permitan optimizar tus acciones dentro del mercado financiero",
        "faq_subtitle": "¿Tienes una pregunta?",
        "caption_news": "noticias",
        "caption_event": "eventos",
        "news_readmore": "leer más",
        "footer_waiting": "¿Qué estás esperando?",
        "carousel_title_0": "Parte de conceptos básicos y genera rentabilidad",
        "carousel_subtitle_0": "Nuestra plataforma esta diseñada para impulsar tu crecimiento profesional y conocer más acerca del mercado financiero, liderado por expertos en inversión.",
        "carousel_title_1": "Accede a nuestra plataforma integral de apredizaje de trading",
        "carousel_subtitle_1": "Aprende a optimizar tus operaciones y aumenta la calidad de tus inversiones con estrategias basadas en análisis de tendencias, patrones e indicadores.",
        "carousel_title_2": "Evoluciona tu estructura mental y comprende las estructuras del mercado financiero",
        "carousel_subtitle_2": "Forma tu conocimiento en trading de manera profesional y da el primer paso para triunfar dentro del mercado financiero con constante rentabilidad.",
        "contact": "Contáctanos",
        "plan_title_0": "Académico",
        "plan_title_1": "Plan Referido 1",
        "plan_title_2": "Plan Referido 2",
        "plan_title_feature_0": ["Ingreso a todo el material audiovisual de la academia","Transferencia de puntos","Agrega tus propios referidos","Descargar facturas"],
        "plan_title_feature_1": ["Adquirir robot o adquirir indicador"],
        "plan_title_feature_2": ["Adquirir robot o adquirir indicador"],
        "tip_title_0":"Formación múltiple",
        "tip_title_1":"Educación flexible",
        "tip_title_2":"Profesionales capacitados",
        "tip_title_3":"Crecimiento profesional",
        "tip_detail_0":"Nuestros cursos combinan clases online, prácticas, webinars, charlas y contenido de valor dictado por traders expertos. Además de acceso a la comunidad de estudiantes que forman parte de Soul Split.",
        "tip_detail_1":"Todo el material educativo se encuentra disponible en nuestra plataforma, revísalo las veces que quieras y cuando lo quieras.",
        "tip_detail_2":"De la mano de profesionales nacionales e internacionales altamente capacitados y con más de 10 años de experiencia en trading.",
        "tip_detail_3":"Nuestro equipo te guiará en el cumplimiento de tus objetivos profesionales a través de nuestra plataforma, tus propias habilidades y un experto en trading.",
      }
    })
  })
}
