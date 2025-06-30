"use client";

import { useEffect, useState } from 'react';
import {
  Container, Typography, CircularProgress, Card, CardContent, Pagination
} from '@mui/material';
import axios from 'axios';
import { Receita } from '@/app/types/receita';

export default function ReceitasPage() {
  const [receitas, setReceitas] = useState([]);
  const [loading, setLoading] = useState(true);
  const [page, setPage] = useState(1);
  const pageSize = 5;

  const token = localStorage.getItem('token');

  useEffect(() => {
    const fetchData = async () => {
      setLoading(true);
      const res = await axios.get('/api/transacoes/receitas', {
        headers: { Authorization: `Bearer ${token}` },
      });
      setReceitas(res.data);
      setLoading(false);
    };
    fetchData();
  }, []);

  const paginated = receitas.slice((page - 1) * pageSize, page * pageSize);

  return (
    <Container sx={{ mt: 4 }}>
      <Typography variant="h4" gutterBottom>Receitas</Typography>
      {loading ? (
        <CircularProgress />
      ) : (
        <>
          {paginated.map((r) => (
            <Card key={r.id} sx={{ mb: 2 }}>
              <CardContent>
                <Typography variant="h6">R$ {r.valor}</Typography>
                <Typography>{r.descricao}</Typography>
                <Typography variant="caption">{new Date(r.data).toLocaleDateString()}</Typography>
              </CardContent>
            </Card>
          ))}
          <Pagination
            count={Math.ceil(receitas.length / pageSize)}
            page={page}
            onChange={(e, value) => setPage(value)}
            sx={{ mt: 2 }}
          />
        </>
      )}
    </Container>
  );
}

