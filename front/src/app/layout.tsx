
import "./globals.css";
import '@fontsource/roboto/300.css';
import '@fontsource/roboto/400.css';
import '@fontsource/roboto/500.css';
import '@fontsource/roboto/700.css';
import { AppBar, Box, Container, CssBaseline, Toolbar, Typography } from "@mui/material";

export default function RootLayout({
  children,
}: Readonly<{
  children: React.ReactNode;
}>) {
  return (
    <html lang="en">
      <body>
        <CssBaseline/>
        {/* Barra de Ferramentas */}
        <AppBar position="static">
          <Toolbar>
            <Typography variant="h6" component="div">
              Recuperação Web Avançado
            </Typography>
          </Toolbar>
        </AppBar>

        {/* Conteúdo - Componentes criados por nós */}
        <Box component="main" sx={{ minHeight: "calc(100vh - 120px)", py: 4 }}>
        <Container>
          {children}
        </Container>
        </Box>
      </body>
    </html>
  );
}