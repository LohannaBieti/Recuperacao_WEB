import React, { useEffect, useState } from 'react';
import axios from 'axios';
import {
  AppBar,
  Box,
  Button,
  Container,
  Tab,
  Tabs,
  Typography,
  List,
  ListItem,
  ListItemText,
  Divider
} from '@mui/material';
import { receitaDespesa } from '@/app/types/receitaDespesa';

function TabPanel(props: { children?: React.ReactNode; value: number; index: number }) {
  const { children, value, index } = props;
  return (
    <div hidden={value !== index}>
      {value === index && <Box sx={{ p: 2 }}>{children}</Box>}
    </div>
  );
}

export default function ReceitasDespesasPage() {
  const [value, setValue] = useState(0);
  const [receitas, setReceitas] = useState<receitaDespesa[]>([]);
  const [despesas, setDespesas] = useState<receitaDespesa[]>([]);

  const token = localStorage.getItem('token');

  const handleChange = (event: React.SyntheticEvent, newValue: number) => {
    setValue(newValue);
  };

  useEffect(() => {
    axios.get('/api/ReceitaDespesa', {
      headers: {
        Authorization: `Bearer ${token}`
      }
    })
      .then(response => {
        const data = response.data;
        setReceitas(data.filter((item: receitaDespesa) => item.isReceita));
        setDespesas(data.filter((item: receitaDespesa) => !item.isReceita));
      })
      .catch(error => {
        console.error('Erro ao carregar dados:', error);
      });
  }, []);

  const renderList = (items: receitaDespesa[]) => (
    <List>
      {items.map((item) => (
        <div key={item.id}>
          <ListItem
            secondaryAction={
              <>
                <Button size="small">Editar</Button>
                <Button size="small" color="error">Excluir</Button>
              </>
            }
          >
            <ListItemText
              primary={`${item.titulo} - R$ ${item.valor.toFixed(2)}`}
              secondary={`Data: ${new Date(item.data).toLocaleDateString()}`}
            />
          </ListItem>
          <Divider />
        </div>
      ))}
    </List>
  );

  return (
    <Container>
      <Box sx={{ width: '100%', mt: 4 }}>
        <AppBar position="static" color="default">
          <Tabs value={value} onChange={handleChange} indicatorColor="primary" textColor="primary" centered>
            <Tab label="Receitas" />
            <Tab label="Despesas" />
          </Tabs>
        </AppBar>

        <TabPanel value={value} index={0}>
          <Typography variant="h5" gutterBottom>Receitas</Typography>
          <Button variant="contained" color="primary" sx={{ mb: 2 }}>
            Nova Receita
          </Button>
          {renderList(receitas)}
        </TabPanel>

        <TabPanel value={value} index={1}>
          <Typography variant="h5" gutterBottom>Despesas</Typography>
          <Button variant="contained" color="primary" sx={{ mb: 2 }}>
            Nova Despesa
          </Button>
          {renderList(despesas)}
        </TabPanel>
      </Box>
    </Container>
  );
}
