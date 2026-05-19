import { View, Text, Pressable } from 'react-native';
import { formStyles as s } from './formStyles';

export default function FormTabs({ options, value, onChange }) {
  return (
    <View style={s.tabRow}>
      {options.map((opt) => {
        const active = value === opt.value;
        return (
          <Pressable
            key={opt.value}
            style={[s.tabButton, active && s.tabButtonActive]}
            onPress={() => onChange(opt.value)}
          >
            <Text style={[s.tabText, active && s.tabTextActive]}>{opt.label}</Text>
          </Pressable>
        );
      })}
    </View>
  );
}
