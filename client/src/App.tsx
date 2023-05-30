
import { Route, Routes } from 'react-router-dom'
import './App.css'
import { Home } from './components/Home'
import { About } from './components/About'

function App() {
  return (
    <div className='container'>
      <header>
        <Routes>
          <Route path="/" element={ <Home/> } />
          <Route path='about' element={ <About/> } />
        </Routes>
      </header>
      <main>

      </main>
    </div>
  )
}

export default App
