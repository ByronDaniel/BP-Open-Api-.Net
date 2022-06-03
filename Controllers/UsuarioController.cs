using Microsoft.AspNetCore.Mvc;

namespace BP.Controllers;

[ApiController]
[Route("[controller]")]
public class UsuarioController : ControllerBase
{

    private static List<Usuario> usuarios = new List<Usuario>()
    {
        new Usuario("1712341234","Byron","Delgado",Convert.ToDateTime("1999-12-12"),800.67),
        new Usuario("1231232133","Jeffeson","Norona",Convert.ToDateTime("1998-02-03"),1000.50)
    };
    public static List<Usuario> getUsuarios()
    {
        return usuarios;
    }

    private readonly ILogger<UsuarioController> _logger;
    public UsuarioController(ILogger<UsuarioController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUsuarios")]
    public IEnumerable<Usuario> GetUsuarios()
    {
        return usuarios;
    }

    [HttpGet("{ci:int}")]
    public Usuario GetUsuario(string ci)
    {
        foreach (Usuario usuario in usuarios)
        {
            if(usuario.Ci == ci)
            {
                return usuario;
            }
        }
        return null;
    }

    [HttpPost]
    public void PostUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
    }

    [HttpDelete("{ci:int}")]
    public void DeleteUsuario(string ci)
    {
        Usuario usuarioSeleccionado = null;
        for (int i = 0; i < usuarios.Count; i++)
        {
            if (usuarios[i].Ci == ci)
            {
                usuarioSeleccionado = usuarios[i];
            }
        }
        if(usuarioSeleccionado != null)
        {
            usuarios.Remove(usuarioSeleccionado);
        }
    }

    [HttpPut("{ci:int}")]
    public void UpdateUsuario(string ci, Usuario usuario)
    {
        for (int i = 0; i < usuarios.Count; i++)
        {
            if (usuarios[i].Ci == ci)
            {
                usuario.Ci = ci;
                usuarios[i] = usuario;
            }
        }
    }
}
